using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("/api/user/register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return BadRequest(new { message = "Username and Password are required" });
            }

            var user = new User
            {
                Username = request.Username,
                Password = request.Password
            };

            _context.DbUsers.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password, string confirmPassword)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Uživatelské jméno a heslo jsou povinné");
                return View();
            }

            if (password != confirmPassword)
            {
                ModelState.AddModelError("", "Hesla se neshodují");
                return View();
            }

            var user = new User
            {
                Username = username,
                Password = password
            };

            _context.DbUsers.Add(user);
            await _context.SaveChangesAsync();

            HttpContext.Session.SetString("username", username);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.DbUsers.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user == null)
            {
                ModelState.AddModelError("", "Neplatné uživatelské jméno nebo heslo");
                return View();
            }

            HttpContext.Session.SetString("username", username);
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
