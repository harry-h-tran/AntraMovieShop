using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Repository
{
    public interface IPurchaseRepository : IRepository<Purchases>
    {
        PagedResultSet<Movie> GetPurchasesByUserId(int userId, int pageSize = 30, int pageIndex = 1);
    }
}
