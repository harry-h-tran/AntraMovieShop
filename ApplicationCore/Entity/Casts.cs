namespace ApplicationCore.Entity
{
    public class Casts
    {
        public int Id { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ProfilePath { get; set; } = string.Empty;

        public ICollection<MovieCasts> Movies { get; set; } = new List<MovieCasts>();
    }
}
