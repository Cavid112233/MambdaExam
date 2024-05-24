using FinalExam.Business.Exceptions;
using FinalExam.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }
        public IActionResult Index()
        {
            var workers = _workerService.GetAllWorkers();
            return View(workers);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
                throw new EntityNotFoundException("");
        }
    }
}
