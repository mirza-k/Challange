using AutoMapper;
using QuizModel.Domain;
using QuizModel.Model;
using QuizRepos;
using QuizRepos.Interfaces;
using QuizServices.Interfaces;

namespace QuizServices.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IQuestionService _questionService;
        private readonly IAnswerService _answerService;
        private readonly IMapper mapper;

        public QuizService(ChallangeDbContext context, IUnitOfWork unitOfWork, IQuestionService questionService, IAnswerService answerService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _questionService = questionService;
            _answerService = answerService;
            this.mapper = mapper;
        }

        public IEnumerable<QuizResponseModel> GetAll()
        {
            var quizzesDomain = _unitOfWork.Quizzes.GetAll();
            return mapper.Map<IEnumerable<Quiz>, IEnumerable<QuizResponseModel>>(quizzesDomain);
        }

        public QuizResponseModel GetById(int id)
        {
            var quizDomain = _unitOfWork.Quizzes.GetById(id);
            var quizVM = mapper.Map<Quiz, QuizResponseModel>(quizDomain);
            if (quizVM == null)
            {
                return null;
            }

            var questions = _questionService.GetQuestionsByQuizId(id);

            var pairOfAnswersAndQuestions = _answerService.GetPairsOfAnswersAndQuestions(id);

            quizVM.Questions = questions.Select(question => new QuizResponseModel.QuestionItem
            {
                Id = question.Id,
                Text = question.Text,
                Answers = pairOfAnswersAndQuestions.ContainsKey(question.Id)
                        ? pairOfAnswersAndQuestions[question.Id].Select(answer => new QuizResponseModel.AnswerItem
                        {
                            Id = answer.Id,
                            Text = answer.Text
                        })
                        : new QuizResponseModel.AnswerItem[0],
                CorrectAnswerId = question.CorrectAnswerId
            });

            quizVM.Links = new Dictionary<string, string>
            {
                {"self", $"/api/quizzes/{id}"},
                {"questions", $"/api/quizzes/{id}/questions"}
            };

            return quizVM;
        }
    }
}
