using QuizModel.Domain;
using QuizRepos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRepos.Implementations
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        public QuizRepository(ChallangeDbContext context) : base(context) { }
    }   
}
