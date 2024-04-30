using BookManagement.API.Data.Models;
using BookManagement.API.Data.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class BooksController : Controller
    {
        public readonly IBookService _service;
        public BooksController(IBookService service)
        {
            _service = service;
        }

        // GET: Books
        public ActionResult Index()
        {
            var result = _service.GetAll();
            return View(result);
        }

        // GET: Books/Details/5
        public ActionResult Details(Guid id)
        {
            var result = _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public ActionResult DetailsStr(string? id)
        {
            var abc = id.Substring(0);
            return View(abc);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book item)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                _service.Add(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        // GET: Books/Delete/5
        public ActionResult Delete(Guid id)
        {
            var result = _service.GetById(id);
            return View(result);
        }

        // POST: Books/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            try
            {
                var result = _service.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                _service.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
