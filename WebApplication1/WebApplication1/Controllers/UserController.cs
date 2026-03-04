using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string email, string password, string confirmPassword)
        {
            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Hesla se neshodují");
                return View();
            }

            // Uložit uživatele do session
            HttpContext.Session.SetString("username", username);
            HttpContext.Session.SetString("email", email);

            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Ovìøit a pøihlásit
            HttpContext.Session.SetString("username", email);
            HttpContext.Session.SetString("isAuthenticated", "true");

            return RedirectToAction("Account");
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }
    }
}
