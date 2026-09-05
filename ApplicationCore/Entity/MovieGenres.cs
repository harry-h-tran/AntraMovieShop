namespace ApplicationCore.Entity
{
    public class MovieGenres
    {
        public int MovieId { get; set; }
        public Movie movie { get; set; } = null;

        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null;
    }
}
