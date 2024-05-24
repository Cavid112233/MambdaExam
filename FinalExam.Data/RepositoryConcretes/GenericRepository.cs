using FinalExam.Core.Models;
using FinalExam.Core.RepositoryAbstract;
using FinalExam.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Data.RepositoryConcretes
{
    public class GenericRepository 
    {
        AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Commit()
        {
            return _appDbContext.Set<T>()
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Worker entity)
        {
            throw new NotImplementedException();
        }

        public Task Get(Func<Worker, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Task GetAll(Func<Worker, bool>? predicate = null)
        {
            throw new NotImplementedException();
        }
    }
}
