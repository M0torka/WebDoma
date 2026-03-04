using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string confirmPassword)
        {
            // Zde by byla validace a uložení do databáze
            TempData["SuccessMessage"] = "Úspěšně registrováno";
            return RedirectToAction("Index");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password, bool rememberMe)
        {
            // Zde by byla autentifikace
            TempData["SuccessMessage"] = "Úspěšně přihlášeno";
            return RedirectToAction("Index");
        }

        public IActionResult Profile()
        {
            return View();
        }
    }
}
