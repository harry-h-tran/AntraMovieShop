namespace ApplicationCore.Model
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public int? RunTime { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string BackdropUrl { get; set; } = string.Empty;
        public decimal? Budget { get; set; }
        public string ImdbUrl { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public decimal? Price { get; set; }
        public decimal? Revenue { get; set; }
        public decimal? Rating { get; set; }
        public ICollection<GenreModel> Genres { get; set; } = null!;
        public ICollection<CastModel> Casts { get; set; } = null!;
        public ICollection<TrailerModel> Trailers { get; set; } = null!;
    }
}
