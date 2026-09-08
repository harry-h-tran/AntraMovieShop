using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Services
{
    public interface IMovieService
    {
        IEnumerable<MovieCardModel> GetTopGrossingMovieCards();
        MovieDetailsModel? GetMovieDetails(int movieId, int? userId);
        IEnumerable<MovieCardModel> GetMoviesByGenre(int id);
        PagedResultSet<MovieCardModel> GetMoviesByGenre(int genreId, int pageSize = 30, int pageIndex = 1, string sortBy = "title_asc");
    }
}
