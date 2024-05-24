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
    public class WorkerRepository : GenericRepository<Worker>, IWorkerRepository
    {
        public WorkerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
