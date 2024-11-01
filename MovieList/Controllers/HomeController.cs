using Microsoft.AspNetCore.Mvc;
using MovieList.Models;
using System.Diagnostics;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private MovieContext context { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieContext ctx)
        {
            _logger = logger;
            context = ctx;
        }
       
        public IActionResult Index()
        {
            var movies = context.Movies.OrderBy(m => m.Name).ToList();
            return View(movies);
        }

       
        // public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
