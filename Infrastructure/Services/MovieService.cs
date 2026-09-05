using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Model;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public MovieDetailsModel? GetMovieDetails(int id)
        {
            var movie = _movieRepository.GetByID(id);
            if (movie == null)
            {
                return null;
            }

            return new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title
            };
        }

        public IEnumerable<MovieCardModel> GetTopGrossingMovieCards()
        {
            var movies = _movieRepository.GetTop30GrossingMovies();

            var movieCards = new List<MovieCardModel>();

            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }

        public IEnumerable<MovieCardModel> GetMoviesByGenre(int id)
        {
            var movies = _movieRepository.GetMoviesByGenre(id);
            var movieCards = new List<MovieCardModel>();
            foreach (var movie in movies)
            {
                movieCards.Add(new MovieCardModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl
                });
            }
            return movieCards;
        }

        public PagedResultSet<MovieCardModel> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1)
        {
            var pagedMovies = _movieRepository.GetMoviesByGenre(genreId, pageSize, pageIndex);
            var movieCards = pagedMovies.results.Select(movie => new MovieCardModel
            {
                Id = movie.Id,
                Title = movie.Title,
                PosterUrl = movie.PosterUrl
            }).ToList();

            return new PagedResultSet<MovieCardModel>
            {
                results = movieCards,
                PageIndex = pagedMovies.PageIndex,
                PageSize = pagedMovies.PageSize,
                TotalPages = pagedMovies.TotalPages,
                TotalResults = pagedMovies.TotalResults
            };
        }

    }
}
