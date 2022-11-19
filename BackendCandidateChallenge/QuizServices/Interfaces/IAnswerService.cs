using QuizModel.Model;

namespace QuizServices.Interfaces
{
    public interface IAnswerService
    {
        public IEnumerable<AnswerViewModel> GetAll();
        public AnswerViewModel GetById(int id);
        public Dictionary<int, List<AnswerViewModel>> GetPairsOfAnswersAndQuestions(int quizId);
    }
}
