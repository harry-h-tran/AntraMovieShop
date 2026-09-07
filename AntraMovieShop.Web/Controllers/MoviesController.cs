using AntraMovieShop.Web.ViewModels.Movies;
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

            var viewModel = new MovieDetailsViewModel
            {
                Id = movieDetails.Id,
                Title = movieDetails.Title,
                Overview = movieDetails.Overview,
                Tagline = movieDetails.Tagline,
                ImdbUrl = movieDetails.ImdbUrl,
                PosterUrl = movieDetails.PosterUrl ?? "/images/default-poster.png",
                BackdropUrl = movieDetails.BackdropUrl,
                Rating = movieDetails.Rating,

                // Conversions & Formatting
                ReleaseYear = movieDetails.ReleaseDate.Year.ToString() ?? string.Empty,
                FormattedReleaseDate = movieDetails.ReleaseDate.ToString("MMM dd, yyyy") ?? "N/A",
                FormattedRuntime = movieDetails.RunTime.HasValue
                    ? $"{movieDetails.RunTime.Value / 60}h {movieDetails.RunTime.Value % 60}m"
                    : "N/A",
                FormattedBudget = movieDetails.Budget.HasValue && movieDetails.Budget > 0
                    ? movieDetails.Budget.Value.ToString("C0")
                    : "N/A",
                FormattedRevenue = movieDetails.Revenue.HasValue && movieDetails.Revenue > 0
                    ? movieDetails.Revenue.Value.ToString("C0")
                    : "N/A",
                FormattedPrice = movieDetails.Price.HasValue
                    ? movieDetails.Price.Value.ToString("C2")
                    : "Not Available",
                FormattedRating = movieDetails.Rating.HasValue
                    ? movieDetails.Rating.Value.ToString("0.0")
                    : "No Reviews Yet",

                // Map Genre, Cast and Trailer DTO collections
                Genres = movieDetails.Genres.Select(g => new GenreViewModel
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToList(),

                Casts = movieDetails.Casts.Select(c => new CastViewModel
                {
                    Id = c.CastId,
                    Name = c.Name,
                    Character = c.CharacterName,
                    ProfilePath = c.ProfilePath
                }).ToList(),
                Trailers = movieDetails.Trailers.Select(t => new TrailerViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    TrailerUrl = t.TrailerUrl
                }).ToList()
            };


            return View(viewModel);
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
