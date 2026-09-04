using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public MovieRepository(MovieShopDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public IEnumerable<Movie> GetTop30GrossingMovies()
        {
            return _dbContext.Movies
                .OrderByDescending(m => m.Revenue)
                .Take(30)
                .ToList();
        }
    }
}
