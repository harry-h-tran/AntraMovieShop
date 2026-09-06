namespace ApplicationCore.Entity
{
    public class Trailers
    {
        public int Id { get; set; }
        public int MovieId { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string TrailerUrl { get; set; } = string.Empty;
        public Movie movie = null!;
    }
}
