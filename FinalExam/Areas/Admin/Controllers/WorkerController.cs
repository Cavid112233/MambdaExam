using Microsoft.AspNetCore.Mvc;

namespace FinalExam.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WorkerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
