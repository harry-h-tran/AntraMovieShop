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

        public PagedResultSet<Purchases> GetPurchasesByUserId(int userId, int pageSize = 30, int pageIndex = 1)
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

            return new PagedResultSet<Purchases>
            {
                results = purchasedMovies,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalPurchases / (double)pageSize),
                TotalResults = totalPurchases
            };
        }

        public PagedResultSet<Purchases> GetAllPurchasesForTopMoviesReport(DateTime? fromDate, DateTime? toDate, int pageSize = 30, int pageIndex = 1)
        {
            var query = _dbContext.Purchases
                .Include(p => p.Movie)
                .AsNoTracking();

            var totalMovies = query.Count();

            if (fromDate.HasValue)
            {
                query = query.Where(p => p.PurchaseDateTime >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                query = query.Where(p => p.PurchaseDateTime <= toDate.Value);
            }

            var purchasedMovies = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResultSet<Purchases>
            {
                results = purchasedMovies,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalMovies / (double)pageSize),
                TotalResults = totalMovies
            };
        }

        public bool IsMoviePurchasedByUser(int movieId, int userId)
        {
            return _dbContext.Purchases
                .AsNoTracking()
                .Any(p => p.UserId == userId && p.MovieId == movieId);
        }
    }
}
