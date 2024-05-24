using FinalExam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services.Abstract
{
    public interface IWorkerService
    {
        Task AddWorker(Worker worker);
        void Deleteworker(int id);
        void Updateworker(int id, Worker newWorker);
        Worker GetWorker(Func<Worker, bool>? predicate = null);
        List<Worker> GetAllworkers(Func<Worker, bool>? predicate = null);
    }
}
