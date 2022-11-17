using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRepos.Interfaces
{
    public interface IUnitOfWork
    {
        int Complete();
    }
}
