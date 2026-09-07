using System.Diagnostics;
using AntraMovieShop.Web.ViewModels;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AntraMovieShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            var movieCards = _movieService.GetTopGrossingMovieCards();
            return View(movieCards);
        }

        [Route("Home/NotFoundPage")]
        public IActionResult NotFoundPage()
        {
            // Renders Views/Shared/NotFoundPage.cshtml
            return View("NotFoundPage");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
