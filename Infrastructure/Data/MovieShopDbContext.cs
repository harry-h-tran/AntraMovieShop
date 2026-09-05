using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenres> MovieGenres { get; set; }
        public DbSet<MovieCasts> MovieCasts { get; set; }
        public DbSet<Casts> Casts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenres>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieCasts>()
                .HasOne(mc => mc.Casts)
                .WithMany(c => c.Movies)
                .HasForeignKey(mc => mc.CastId);

            modelBuilder.Entity<MovieCasts>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });
        }
    }
}
