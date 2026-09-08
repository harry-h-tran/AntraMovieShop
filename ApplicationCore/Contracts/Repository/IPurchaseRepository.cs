using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Repository
{
    public interface IPurchaseRepository : IRepository<Purchases>
    {
        PagedResultSet<Purchases> GetPurchasesByUserId(int userId, int pageSize = 30, int pageIndex = 1);

        PagedResultSet<Purchases> GetAllPurchasesForTopMoviesReport(DateTime? fromDate, DateTime? toDate, int pageSize = 30, int pageIndex = 1);

        bool IsMoviePurchasedByUser(int movieId, int userId);
    }
}
