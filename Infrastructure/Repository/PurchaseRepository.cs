using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class PurchaseRepository : BaseRepository<Purchases>, IPurchaseRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public PurchaseRepository(MovieShopDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Purchases> GetPurchasesByUserId(int userId)
        {
            return _dbContext.Purchases
                .Include(p => p.Movie)
                .Where(p => p.UserId == userId)
                .ToList();
        }
    }
}
