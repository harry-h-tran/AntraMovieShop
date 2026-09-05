namespace ApplicationCore.Entity
{
    public class MovieCasts
    {
        public int CastId { get; set; }
        public string Character { get; set; } = string.Empty;
        public int MovieId { get; set; }

        public Movie Movie { get; set; } = null!;
        public Casts Casts { get; set; } = null!;
    }
}
