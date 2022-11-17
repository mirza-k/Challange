using QuizModel.Domain;

namespace QuizRepos.Interfaces
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IEnumerable<Question> GetQuestionsByQuizId(int quizId);
    }
}
