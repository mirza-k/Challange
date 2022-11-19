using QuizModel.Model;

namespace QuizServices.Interfaces
{
    public interface IQuestionService
    {
        IEnumerable<QuestionViewModel> GetAll();
        QuestionViewModel GetById(int id);
        public IEnumerable<QuestionViewModel> GetQuestionsByQuizId(int quizId);
    }
}
