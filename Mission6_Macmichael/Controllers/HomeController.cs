using Microsoft.AspNetCore.Mvc;
using Mission6_Macmichael.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission6_Macmichael.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext temp) 
        {
            _context = temp;
        }
        public IActionResult Index()
        {
            //show landing page
            return View();
        }

        public IActionResult GetToKnow()
        {
            //show GetToKnow page
            return View();
        }

        [HttpGet]
        public IActionResult Movie()
        {
            return View(new Movie());
        }
        [HttpPost]
        public IActionResult Movie(Movie response)
        {
            if (ModelState.IsValid)
            {
                //Add record to the database and save it
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation");
            }
            else
            {
                return View(response);
            }
            
        }
        public IActionResult MovieTable()
        {
            var movies = _context.Movies
                .OrderBy(x => x.Title)
                .Select(x => new Movie
                {
                    MovieId = x.MovieId,
                    CategoryId = x.CategoryId,
                    Title = x.Title ?? "",
                    Year = x.Year ?? "",
                    Director = x.Director ?? "",
                    Rating = x.Rating ?? "",
                    Edited = x.Edited,
                    LentTo = x.LentTo ?? "",
                    CopiedToPlex = x.CopiedToPlex,
                    Notes = x.Notes ?? "",
                })
                .ToList();

            return View(movies);
        }

        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            return View("Movie", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie recordToDelete)
        {
            _context.Movies.Remove(recordToDelete);
            _context.SaveChanges();

            return RedirectToAction("MovieTable");
        }

    }
}
