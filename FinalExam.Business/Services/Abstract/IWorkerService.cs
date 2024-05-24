using FinalExam.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services.Abstract
{
    public interface IWorkerService
    {
        Worker AddWorker(Worker worker);
        void DeleteWorker(int id);
        Worker Update(int id, Worker newWorker);
        Worker GetWorker(Func<Worker, bool>? func = null);
        List<Worker> GetAllWorkers(Func<Worker, bool>? func = null);
    }
}
