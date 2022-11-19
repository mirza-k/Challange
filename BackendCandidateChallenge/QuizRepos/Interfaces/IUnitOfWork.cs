using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRepos.Interfaces
{
    public interface IUnitOfWork
    {
        public IQuizRepository Quizzes{ get; set; }
        public IQuestionRepository Questions { get; set; }
        public IAnswerRepository Answers { get; set; }
        int Complete();
    }
}
