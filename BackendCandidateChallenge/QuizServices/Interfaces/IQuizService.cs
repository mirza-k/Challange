using QuizModel.Model;

namespace QuizServices.Interfaces
{
    public interface IQuizService
    {
        IEnumerable<QuizResponseModel> GetAll();
        QuizResponseModel GetById(int id);
    }
}
