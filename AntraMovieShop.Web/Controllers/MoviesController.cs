using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AntraMovieShop.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            var movieDetails = _movieService.GetMovieDetails(id);
            if (movieDetails == null)
            {
                return NotFound();
            }
            return View(movieDetails);
        }

        public IActionResult Genre(int id, int pageIndex = 1, int pageSize = 30, string sortBy = "title_asc")
        {
            var genreDetails = _movieService.GetMoviesByGenre(id, pageSize, pageIndex, sortBy);
            if (genreDetails == null)
            {
                return NotFound();
            }
            ViewBag.GenreId = id;
            ViewBag.CurrentSort = sortBy;
            return View(genreDetails);
        }
    }
}
