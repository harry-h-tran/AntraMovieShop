namespace AntraMovieShop.Web.ViewModels.Movies
{
    public class MovieDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Overview { get; set; }
        public string? Tagline { get; set; }
        public string? ImdbUrl { get; set; }
        public string? PosterUrl { get; set; }
        public string? BackdropUrl { get; set; }
        public decimal? Rating { get; set; }

        // Display-formatted properties
        public string ReleaseYear { get; set; } = string.Empty;
        public string FormattedReleaseDate { get; set; } = string.Empty;
        public string FormattedRuntime { get; set; } = string.Empty;
        public string FormattedBudget { get; set; } = string.Empty;
        public string FormattedRevenue { get; set; } = string.Empty;
        public string FormattedPrice { get; set; } = string.Empty;

        // UI Flags
        public bool HasBackdrop => !string.IsNullOrEmpty(BackdropUrl);
        public bool HasTagline => !string.IsNullOrEmpty(Tagline);
        public bool HasImdbLink => !string.IsNullOrEmpty(ImdbUrl);
        public bool HasCast => Casts.Any();
        public bool HasGenres => Genres.Any();

        // UI-facing collections for Cast and Genre
        public List<GenreViewModel> Genres { get; set; } = new();
        public List<CastViewModel> Casts { get; set; } = new();
        public List<TrailerViewModel> Trailers { get; set; } = new();
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class CastViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Character { get; set; } = string.Empty;
        public string ProfilePath { get; set; } = string.Empty;

        // Visual helper for missing profile images
        public bool HasProfilePath => !string.IsNullOrEmpty(ProfilePath);
    }

    public class TrailerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        // Visual helper for missing trailer URLs
        public bool HasTrailerUrl => !string.IsNullOrEmpty(TrailerUrl);
    }
}