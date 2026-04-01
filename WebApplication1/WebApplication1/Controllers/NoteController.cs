using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
