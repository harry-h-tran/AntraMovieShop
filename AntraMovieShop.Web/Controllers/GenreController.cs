using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Microsoft.AspNetCore.Mvc;

namespace AntraMovieShop.Web.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public IActionResult Index()
        {
            IEnumerable<Genre> genres = _genreRepository.GetAll();
            return View(genres);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Genre genre)
        {
            if(ModelState.IsValid)
            {
                _genreRepository.Insert(genre);
                return RedirectToAction("Index");
            }
            return View(genre);
        }
    }
}
