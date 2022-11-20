using System.Collections.Generic;

namespace QuizClient.Model
{
    public class QuizResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Question> Questions { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
