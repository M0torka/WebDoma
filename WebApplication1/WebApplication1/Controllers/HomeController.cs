using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Challenges()
        {
            return View();
        }

        public IActionResult OMne()
        {
            return View();
        }

        public IActionResult Recenze()
        {
            return View();
        }
    }
}
