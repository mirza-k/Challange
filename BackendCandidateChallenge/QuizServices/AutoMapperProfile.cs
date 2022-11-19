using AutoMapper;
using QuizModel.Domain;
using QuizModel.Model;

namespace QuizServices
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Question, QuestionViewModel>();
            CreateMap<Answer, AnswerViewModel>().ReverseMap();
            CreateMap<Quiz, QuizResponseModel>();
            CreateMap<QuestionViewModel, QuizResponseModel.QuestionItem>();
        }
    }
}
