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
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        AppDbContext _appDbContext;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _appDbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
        }

        public T Get(Func<T, bool>? predicate = null)
        {
            return predicate == null ?
                _appDbContext.Set<T>().FirstOrDefault() :
                _appDbContext.Set<T>().FirstOrDefault(predicate);
        }

        public List<T> GetAll(Func<T, bool>? predicate = null)
        {
            return predicate == null ?
                _appDbContext.Set<T>().ToList() :
                _appDbContext.Set<T>().Where(predicate).ToList();
        }
    }
}
