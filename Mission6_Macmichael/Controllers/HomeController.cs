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
            //show Movie page
            return View();
        }
        [HttpPost]
        public IActionResult Movie(Movie response)
        {
            //Add record to the database and save it
            _context.Movies.Add(response); 
            _context.SaveChanges();

            return View("Confirmation");
        }
    }
}
