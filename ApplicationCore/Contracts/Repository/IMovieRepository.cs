using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<Movie> GetTop30GrossingMovies();
        IEnumerable<Movie> GetMoviesByGenre(int genreId);
        PagedResultSet<Movie> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1, string sortBy = "title_asc");
    }
}
