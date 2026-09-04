using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext:DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
        {
            
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

    }
}
