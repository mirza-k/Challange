using AutoMapper;
using QuizModel.Domain;
using QuizModel.Model;
using QuizRepos.Interfaces;
using QuizServices.Interfaces;

namespace QuizServices.Implementations
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<QuestionViewModel> GetAll()
        {
            var questionsDomain = _unitOfWork.Questions.GetAll();
            return mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(questionsDomain);
        }

        public QuestionViewModel GetById(int id)
        {
            var questionDomain = _unitOfWork.Questions.GetById(id);
            return mapper.Map<QuestionViewModel>(questionDomain);
        }

        public IEnumerable<QuestionViewModel> GetQuestionsByQuizId(int quizId)
        {
            var questionDomain = _unitOfWork.Questions.GetQuestionsByQuizId(quizId);

            return mapper.Map<IEnumerable<Question>, IEnumerable<QuestionViewModel>>(questionDomain);
        }
    }
}
