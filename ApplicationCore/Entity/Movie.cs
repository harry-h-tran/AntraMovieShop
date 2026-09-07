using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entity
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string? BackdropUrl { get; set; }
        public decimal? Budget { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ImdbUrl { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? Overview { get; set; }
        public string? PosterUrl { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal? Revenue { get; set; }
        public int? RunTime { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public string? TmdbUrl { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        // Navigation properties
        public ICollection<MovieGenres> Genres { get; set; } = new List<MovieGenres>();
        public ICollection<MovieCasts> Casts { get; set; } = new List<MovieCasts>();
        public ICollection<Trailers> Trailers { get; set; } = new List<Trailers>();
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();

    }
}
