using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NoteController : Controller
    {
        // Dočasné úložiště (bez databáze)
        private static List<Note> _notes = new();
        private static int _nextId = 1;

        // GET /Note/List
        public IActionResult List()
        {
            return View(_notes);
        }

        // GET /Note/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST /Note/Add
        [HttpPost]
        public IActionResult Add(Note note)
        {
            if (ModelState.IsValid)
            {
                note.Id = _nextId++;
                note.CreatedAt = DateTime.Now;
                _notes.Add(note);
                return RedirectToAction("List");
            }
            return View(note);
        }
    }
}