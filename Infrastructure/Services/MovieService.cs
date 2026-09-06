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
            var movie = _movieRepository.GetMovieByIdWithDetails(id);
            if (movie == null)
            {
                return null;
            }

            return new MovieDetailsModel
            {
                Id = movie.Id,
                Title = movie.Title,
                Tagline = movie.Tagline,
                RunTime = movie.RunTime,
                ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate ?? DateTime.MinValue),
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                ImdbUrl = movie.ImdbUrl,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Price = movie.Price,
                Genres = movie.Genres.Select(g => new GenreModel
                {
                    Id = g.Genre.Id,
                    Name = g.Genre.Name
                }).ToList(),
                Casts = movie.Casts.Select(mc => new CastModel
                {
                    CastId = mc.CastId,
                    Name = mc.Casts.Name,
                    CharacterName = mc.Character,
                    ProfilePath = mc.Casts.ProfilePath
                }).ToList()
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

        public PagedResultSet<MovieCardModel> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1, string sortBy = "title_asc")
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
