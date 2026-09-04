using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDbContext context) : base(context)
        {
        }
    }
}
