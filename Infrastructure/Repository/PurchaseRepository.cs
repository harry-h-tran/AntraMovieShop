using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using ApplicationCore.Model;
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

        public PagedResultSet<Movie> GetPurchasesByUserId(int userId, int pageSize = 30, int pageIndex = 1)
        {
            var query = _dbContext.Purchases
                .Include(p => p.Movie)
                .Where(p => p.UserId == userId);

            var totalPurchases = query.Count();

            query = query.OrderByDescending(p => p.PurchaseDateTime);

            var purchasedMovies = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResultSet<Movie>
            {
                results = purchasedMovies.Select(p => p.Movie).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalPurchases / (double)pageSize),
                TotalResults = totalPurchases
            };
        }
    }
}
