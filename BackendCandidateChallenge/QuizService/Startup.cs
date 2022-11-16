using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace QuizService;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ChallangeDbContext>(option => option.UseInMemoryDatabase("Data Source=:memory:"));
        services.AddMvc();
        services.AddSingleton(InitializeDb());
        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        var context = app.ApplicationServices.GetService<ChallangeDbContext>();
        DataSeedForEF(context);
    }

    private IDbConnection InitializeDb()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        // Migrate up
        var assembly = typeof(Startup).GetTypeInfo().Assembly;
        var migrationResourceNames = assembly.GetManifestResourceNames()
            .Where(x => x.EndsWith(".sql"))
            .OrderBy(x => x);
        if (!migrationResourceNames.Any()) throw new System.Exception("No migration files found!");
        foreach (var resourceName in migrationResourceNames)
        {
            var sql = GetResourceText(assembly, resourceName);
            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        return connection;
    }

    private static string GetResourceText(Assembly assembly, string resourceName)
    {
        using (var stream = assembly.GetManifestResourceStream(resourceName))
        {
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }

    //  Probably it's not happiest way to seed data but I found it as only way in
    //  case when using in-memory database with EF in-memory database in this case
    //  is NoSQL an non-relational and couldn't execute SQL scripts.
    private void DataSeedForEF(ChallangeDbContext context)
    {
        context.Database.EnsureDeleted();

        var quiz1 = new QuizModel.Domain.Quiz() { Id = 1, Title = "My first quiz" };
        var quiz2 = new QuizModel.Domain.Quiz() { Id = 2, Title = "My second quiz" };
        var question1 = new QuizModel.Domain.Question() { Id = 1, Text = "My first question" };
        var answer1 = new QuizModel.Domain.Answer() { Id = 1, Text = "My first answer to first q" };
        var answer2 = new QuizModel.Domain.Answer() { Id = 2, Text = "My second answer to first q" };
        question1.CorrectAnswerId = 1;

        var question2 = new QuizModel.Domain.Question() { Id = 2, Text = "My second question" };
        var answer3 = new QuizModel.Domain.Answer() { Id = 3, Text = "My first answer to second q" };
        var answer4 = new QuizModel.Domain.Answer() { Id = 4, Text = "My second answer to second q" };
        var answer5 = new QuizModel.Domain.Answer() { Id = 5, Text = "My third answer to second q" };
        question2.CorrectAnswerId = 5;

        context.Quizzes.AddRange(quiz1, quiz2);
        context.Questions.AddRange(question1, question2);
        context.Answers.AddRange(answer1, answer2, answer3, answer4, answer5);

        context.SaveChanges();
    }
}