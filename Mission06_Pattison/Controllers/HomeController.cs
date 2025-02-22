using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Pattison.Models;

namespace Mission06_Pattison.Controllers
{
    public class HomeController : Controller
    {
        private readonly MovieListContext _context;

        // Constructor to initialize the database context
        public HomeController(MovieListContext temp)
        {
            _context = temp;
        }

        // Landing page
        public IActionResult Index()
        {
            return View();
        }

        // Page to learn more about Joel Hilton
        public IActionResult GetToKnow()
        {
            return View();
        }

        // Display the form to add a new movie
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View(new Movie());
        }

        // Handles form submission for adding a new movie
        [HttpPost]
        public IActionResult AddMovie(Movie response)
        {
            if (!ModelState.IsValid)
            {
                // Repopulate the categories if the form validation fails
                ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
                return View(response);
            }

            // Assign category reference and save to database
            response.Category = _context.Categories.Find(response.CategoryId);
            _context.Movies.Add(response);
            _context.SaveChanges();

            return RedirectToAction("MoviesCollection");
        }

        // Displays a confirmation page after adding a movie
        public IActionResult Confirmation()
        {
            return View();
        }

        // Displays the collection of movies
        public IActionResult MoviesCollection()
        {
            var movies = _context.Movies
                .Include(c => c.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }

        // Load the edit form for a specific movie
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Include(c => c.Category)
                .Single(x => x.MovieId == id);

            // Populate category dropdown
            ViewBag.Categories = _context.Categories.OrderBy(x => x.CategoryName).ToList();
            return View("AddMovie", recordToEdit);
        }

        // Handles form submission for updating a movie
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MoviesCollection");
        }

        // Load the delete confirmation page
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Include(c => c.Category)
                .Single(x => x.MovieId == id);
            return View(recordToDelete);
        }

        // Handles the deletion of a movie
        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MoviesCollection");
        }
    }
}
