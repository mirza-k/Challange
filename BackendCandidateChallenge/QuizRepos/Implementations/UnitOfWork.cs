using QuizRepos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizRepos.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChallangeDbContext _context;

        public UnitOfWork(ChallangeDbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
