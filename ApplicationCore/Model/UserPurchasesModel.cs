namespace ApplicationCore.Model
{
    public class UserPurchasesModel
    {
        public Guid PurchaseNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public MovieCardModel MovieCard { get; set; }
    }
}
