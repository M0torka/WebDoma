using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NoteController : Controller
    {
        private readonly AppDbContext _context;

        public NoteController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            var username = HttpContext.Session.GetString("username");
            var user = _context.DbUsers.FirstOrDefault(u => u.Username == username);
            if (user == null) return RedirectToAction("Login", "User");

            var notes = _context.DbNotes
                .Where(n => n.UserId == user.Id)
                .OrderByDescending(n => n.CreatedAt)
                .ToList();

            return View(notes);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note note)
        {
            var username = HttpContext.Session.GetString("username");
            var user = _context.DbUsers.FirstOrDefault(u => u.Username == username);
            if (user == null) return RedirectToAction("Login", "User");

            note.UserId = user.Id;
            note.CreatedAt = DateTime.Now;
            _context.DbNotes.Add(note);
            _context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}