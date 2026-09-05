namespace ApplicationCore.Model
{
    public class MovieDetailsModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Tagline { get; set; } = string.Empty;
        public int? RunTime { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public string BackdropUrl { get; set; } = string.Empty;
        public decimal? Budget { get; set; }
        public string ImdbUrl { get; set; } = string.Empty;
        public string Overview { get; set; } = string.Empty;
        public string PosterUrl { get; set; } = string.Empty;
        public decimal? Price { get; set; }

        // Need Reviews Score Average
        public ICollection<GenreModel> Genres { get; set; } = new List<GenreModel>();
        public ICollection<CastModel> Casts { get; set; } = new List<CastModel>();
    }
}
