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
        public DbSet<Trailers> Trailers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieGenres>()
                .HasKey(mg => new { mg.MovieId, mg.GenreId });

            modelBuilder.Entity<MovieCasts>()
                .HasKey(mc => new { mc.MovieId, mc.CastId });

            modelBuilder.Entity<UserRoles>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<MovieCasts>()
                .HasOne(mc => mc.Movie)
                .WithMany(m => m.Casts)
                .HasForeignKey(mc => mc.MovieId);

            modelBuilder.Entity<MovieCasts>()
                .HasOne(mc => mc.Casts)
                .WithMany(c => c.Movies)
                .HasForeignKey(mc => mc.CastId);

            modelBuilder.Entity<Trailers>()
                .HasOne(t => t.movie)
                .WithMany(m => m.Trailers)
                .HasForeignKey(t => t.MovieId);

        }
    }
}
