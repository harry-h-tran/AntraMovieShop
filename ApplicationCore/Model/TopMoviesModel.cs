namespace ApplicationCore.Model
{
    public class TopMoviesModel
    {
        public int Rank { get; set; }
        public string Title { get; set; } = string.Empty;
        public int TotalPurchases { get; set; }
        public int MovieId { get; set; }
    }
}
