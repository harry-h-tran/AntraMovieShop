using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Services
{
    public interface IAdminService
    {
        PagedResultSet<TopMoviesModel> GetTopMovies(DateTime? fromDate, DateTime? toDate);
    }
}
