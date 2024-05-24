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
        void DeleteAsync(T entity);
        Task Get(Func<T, bool>? predicate = null);
        Task GetAll(Func<T, bool>? predicate = null);
        int Commit();
        Task<int> CommitAsync();
    }
}
