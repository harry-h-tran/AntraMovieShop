namespace ApplicationCore.Entity
{
    public class Reviews
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; } = string.Empty;

        // Navigation properties
        public Movie Movie { get; set; } = null!;
        public Users User { get; set; } = null!;

    }
}
