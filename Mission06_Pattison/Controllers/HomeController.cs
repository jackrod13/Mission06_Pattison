using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Pattison.Models;

namespace Mission06_Pattison.Controllers
{
    public class HomeController : Controller
    {
        private MovieListContext _context;

        public HomeController(MovieListContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        public IActionResult MoviesCollection()
        {
            return View(new AddMovieForm());
        }

        [HttpPost]
        public IActionResult MoviesCollection(AddMovieForm response)
        {
            if (ModelState.IsValid)
            {
                _context.MovieList.Add(response);
                _context.SaveChanges();

                return RedirectToAction("Confirmation");
            }

            return View(response); 
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
