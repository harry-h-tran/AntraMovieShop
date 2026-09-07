using ApplicationCore.Entity;

namespace ApplicationCore.Contracts.Repository
{
    public interface IPurchaseRepository : IRepository<Purchases>
    {
        IEnumerable<Purchases> GetPurchasesByUserId(int userId);
    }
}
