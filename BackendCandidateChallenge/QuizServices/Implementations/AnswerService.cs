using AutoMapper;
using QuizModel.Domain;
using QuizModel.Model;
using QuizRepos.Interfaces;
using QuizServices.Interfaces;

namespace QuizServices.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            this.mapper = mapper;
        }

        public IEnumerable<AnswerViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AnswerViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<AnswerViewModel>> GetPairsOfAnswersAndQuestions(int quizId)
        {
            var domainDictionary = _unitOfWork.Answers.GetPairsOfAnswersAndQuestions(quizId);

            return domainDictionary.ToDictionary(k => k.Key, v => mapper.Map<List<Answer>, List<AnswerViewModel>>(v.Value));
        }
    }
}
