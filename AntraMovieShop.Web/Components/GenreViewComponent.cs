using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace MovieShop.UI.Components
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public IViewComponentResult Invoke()
        {
            var genres = _genreService.GetAll();
            return View(genres);
        }
    }
}