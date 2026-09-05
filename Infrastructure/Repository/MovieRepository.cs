using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using ApplicationCore.Model;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public MovieRepository(MovieShopDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Movie> GetTop30GrossingMovies()
        {
            return _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(30)
                .ToList();
        }

        public IEnumerable<Movie> GetMoviesByGenre(int genreId)
        {
            return _dbContext.Movies
                .Where(m => m.Genres.Any(mg => mg.GenreId == genreId))
                .ToList();
        }

        public PagedResultSet<Movie> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1, string sortBy = "title_asc")
        {
            var query = _dbContext.Movies
                .Where(m => m.Genres.Any(mg => mg.GenreId == genreId));

            var totalMovies = query.Count();

            query = sortBy.ToLower() switch
            {
                "title_asc" => query.OrderBy(m => m.Title),
                "title_desc" => query.OrderByDescending(m => m.Title),
                "release_date_asc" => query.OrderBy(m => m.ReleaseDate),
                "release_date_desc" => query.OrderByDescending(m => m.ReleaseDate),
                _ => query.OrderBy(m => m.Id)
            };

            var movies = query
                .OrderBy(m => m.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResultSet<Movie>
            {
                results = movies,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                TotalResults = totalMovies
            };
        }
    }
}
