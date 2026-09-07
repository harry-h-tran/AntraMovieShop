namespace ApplicationCore.Entity
{
    public class Purchases
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDateTime { get; set; }
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }

        // Navigation properties
        public Movie Movie { get; set; }
        public Users User { get; set; }
    }
}
