using FinalExam.Business.Exceptions;
using FinalExam.Business.Services.Abstract;
using FinalExam.Core.Models;
using FinalExam.Core.RepositoryAbstract;
using FinalExam.Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.Business.Services.Concretes
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        private readonly IWebHostEnvironment _env;
        public WorkerService(IWorkerRepository workerRepository, IWebHostEnvironment env)
        {
            _workerRepository = workerRepository;
            _env = env;
        }

        public async Worker AddWorker(Worker worker)
        {
            await _workerRepository.AddAsync(worker);
        }

        public void DeleteWorker(int id)
        {
            throw new NotImplementedException();
        }

        public List<Worker> GetAllWorkers(Func<Worker, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        

        public Worker GetWorker(Func<Worker, bool>? func = null)
        {
            throw new NotImplementedException();
        }

        public Worker Update(int id, Worker newWorker)
        {
            throw new NotImplementedException();
        }
    }
}
