using QuizModel.Domain;

namespace QuizRepos.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Dictionary<int, List<Answer>> GetPairsOfAnswersAndQuestions(int quizId);
    }
}
