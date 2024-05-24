using FinalExam.Business.Exceptions;
using FinalExam.Business.Extensions;
using FinalExam.Business.Services.Abstract;
using FinalExam.Core.Models;
using FinalExam.Core.RepositoryAbstract;
using FinalExam.Data.RepositoryConcretes;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using FileNotFoundException = FinalExam.Business.Exceptions.FileNotFoundException;

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

        public async Task AddWorker(Worker worker)
        {
            if (worker.ImageFile == null)
                throw new FileNotFoundException("File bos ola bilmez!");

            worker.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads/workers", worker.ImageFile);
            await _workerRepository.AddAsync(worker);
            await _workerRepository.CommitAsync();
        }

        public void Deleteworker(int id)
        {
            var existWorker = _workerRepository.Get(x => x.Id == id);
            if (existWorker == null)
                throw new EntityNotFoundException("Worker tapilmadi!");
            Helper.DeleteFile(_env.WebRootPath, @"uploads\workers", existWorker.ImageUrl);

            _workerRepository.Delete(existWorker);
            _workerRepository.Commit();
        }

        public List<Worker> GetAllworkers(Func<Worker, bool>? predicate = null)
        {
            return _workerRepository.GetAll(predicate);
        }

        public Worker GetWorker(Func<Worker, bool>? predicate = null)
        {
            return _workerRepository.Get(predicate);
        }

        public void Updateworker(int id, Worker newWorker)
        {
            var oldWorker = _workerRepository.Get(x => x.Id == id);

            if (oldWorker == null)
                throw new EntityNotFoundException("Blog tapilmadi!");

            if (newWorker.ImageFile != null)
            {
                Helper.DeleteFile(_env.WebRootPath, @"uploads\workers", oldWorker.ImageUrl);
                oldWorker.ImageUrl = Helper.SaveFile(_env.WebRootPath, @"uploads\workers", newWorker.ImageFile);
            }
            oldWorker.FullName = newWorker.FullName;
            oldWorker.Experience = newWorker.Experience;
            oldWorker.FbLink = newWorker.FbLink;
            oldWorker.InstaUrl = newWorker.InstaUrl;
            oldWorker.XUrl = newWorker.XUrl;
            oldWorker.LinkEdnUrl = newWorker.LinkEdnUrl;


            _workerRepository.Commit();
        }
    }
}
