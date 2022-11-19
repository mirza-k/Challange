using QuizRepos.Interfaces;

namespace QuizRepos.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallangeDbContext _context;
        public IQuizRepository Quizzes { get; set; }
        public IQuestionRepository Questions { get; set; }
        public IAnswerRepository Answers { get; set; }

        public UnitOfWork(ChallangeDbContext context)
        {
            _context = context;
            Quizzes = new QuizRepository(_context);
            Questions = new QuestionRepository(_context);
            Answers = new AnswerRepository(_context);
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
