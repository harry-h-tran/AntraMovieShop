using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Model;

namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IPurchaseRepository _purchaseRepository;

        public AdminService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }

        public PagedResultSet<TopMoviesModel> GetTopMovies(DateTime? fromDate, DateTime? toDate)
        {
            var purchasesResultSet = _purchaseRepository.GetAllPurchasesForTopMoviesReport(fromDate, toDate);

            if (purchasesResultSet == null)
            {
                return null;
            }

            var topMovies = purchasesResultSet.results
                .GroupBy(p => p.MovieId)
                .Select(g => new TopMoviesModel
                {
                    Rank = 0, // Placeholder, will be set later
                    Title = g.First().Movie.Title,
                    TotalPurchases = g.Count(),
                    MovieId = g.First().MovieId
                })
                .OrderByDescending(m => m.TotalPurchases)
                    .ThenBy(m => m.Title)
                .ToList();

            // Set the rank for each movie
            for (int i = 0; i < topMovies.Count; i++)
            {
                topMovies[i].Rank = i + 1;
            }

            return new PagedResultSet<TopMoviesModel>
            {
                results = topMovies,
                PageIndex = purchasesResultSet.PageIndex,
                PageSize = purchasesResultSet.PageSize,
                TotalPages = purchasesResultSet.TotalPages,
                TotalResults = purchasesResultSet.TotalResults
            };
        }
    }
}
