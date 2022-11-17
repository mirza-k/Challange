using QuizModel.Domain;
using QuizRepos.Interfaces;

namespace QuizRepos.Implementations
{
    internal class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(ChallangeDbContext context) : base(context)
        {
        }

        public IEnumerable<Question> GetQuestionsByQuizId(int quizId)
        {
            return _context.Questions.Where(x => x.QuizId == quizId).ToList();
        }
    }
}
