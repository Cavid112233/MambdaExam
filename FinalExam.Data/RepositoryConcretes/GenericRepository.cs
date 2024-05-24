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
    public class GenericRepository : IGenericRepository<Worker>
    {
        AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task AddAsync(Worker entity)
        {
            throw new NotImplementedException();
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public void DeleteAsync(Worker entity)
        {
            _appDbContext.Set<T>
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
