using Microsoft.EntityFrameworkCore;
using QuizModel.Domain;

namespace QuizService
{
    public class ChallangeDbContext : DbContext
    {
        public ChallangeDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
