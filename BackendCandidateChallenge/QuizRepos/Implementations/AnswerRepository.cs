using QuizModel.Domain;
using QuizRepos.Interfaces;

namespace QuizRepos.Implementations
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ChallangeDbContext context) : base(context) { }

        public IEnumerable<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Answer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, List<Answer>> GetPairsOfAnswersAndQuestions(int quizId)
        {
            var list = (from answer in _context.Answers
                        join question in _context.Questions on answer.QuestionId equals question.Id
                        join quiz in _context.Quizzes on question.QuizId equals quiz.Id
                        where quiz.Id == quizId
                        select new Answer { Id = answer.Id, QuestionId = answer.QuestionId, Text = answer.Text }).ToList();

            var dictionary = list.Aggregate(new Dictionary<int, List<Answer>>(), (dict, answer) =>
            {
                if (!dict.ContainsKey(answer.QuestionId))
                    dict.Add(answer.QuestionId, new List<Answer>());
                dict[answer.QuestionId].Add(answer);
                return dict;
            });

            return dictionary;
        }
    }
}
