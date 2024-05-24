using FinalExam.Business.Exceptions;
using FinalExam.Business.Services.Abstract;
using FinalExam.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]
    public class WorkerController : Controller
    {
            private readonly IWorkerService _workerService;
            public WorkerController(IWorkerService workerService)
            {
                _workerService = workerService;
            }

            public IActionResult Index()
            {
                var workers = _workerService.GetAllworkers();
                return View(workers);
            }
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Create(Worker worker)
            {
                if (!ModelState.IsValid)
                    return View();

                try
                {
                    await _workerService.AddWorker(worker);
                }
                catch (ImageContentException ex)
                {
                    ModelState.AddModelError("ImageFile", ex.Message);
                    return View();
                }
                catch (ImageSizeException ex)
                {
                    ModelState.AddModelError("ImageFile", ex.Message);
                    return View();
                }
                catch (FileNullReferenceException ex)
                {
                    ModelState.AddModelError("ImageFile", ex.Message);
                    return View();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return RedirectToAction("Index");
            }
            public IActionResult Update(int id)
            {
                var existWorker = _workerService.GetWorker(x => x.Id == id);
                if (existWorker == null) return NotFound();
                return View(existWorker);
            }
            [HttpPost]
            public IActionResult Update(Worker worker)
            {
                if (!ModelState.IsValid)
                    return View();

                try
                {
                    _workerService.Updateworker(worker.Id, worker);
                }
                catch (EntityNotFoundException ex)
                {
                    return NotFound();
                }
                catch (ImageContentException ex)
                {
                    ModelState.AddModelError("ImageFile", ex.Message);
                    return View();
                }
                catch (ImageSizeException ex)
                {
                    ModelState.AddModelError("ImageFile", ex.Message);
                    return View();
                }
                catch (FinalExam.Business.Exceptions.FileNotFoundException ex)
                {
                    ModelState.AddModelError("ImageFile", ex.Message);
                    return View();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }


                return RedirectToAction("Index");
            }
            public IActionResult Delete(int id)
            {
                var existWorker = _workerService.GetWorker(x => x.Id == id);
                if (existWorker == null) return NotFound();
                return View(existWorker);
            }

            [HttpPost]
            public IActionResult DeletePost(int id)
            {

                try
                {
                    _workerService.Deleteworker(id);
                }
                catch (EntityNotFoundException ex)
                {
                    return NotFound();
                }
                catch (FinalExam.Business.Exceptions.FileNotFoundException ex)
                {
                    return NotFound();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return RedirectToAction("Index");
            }
    }
}
