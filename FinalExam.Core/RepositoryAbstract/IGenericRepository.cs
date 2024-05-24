using FinalExam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Core.RepositoryAbstract
{
    public interface IGenericRepository<T> where T : BaseEntity, new()
    {
        Task AddAsync(T entity);
        void Delete(T entity);
        T Get(Func<T, bool>? predicate = null);
        List<T> GetAll(Func<T, bool>? predicate = null);
        int Commit();
        Task<int> CommitAsync();
    }
}
