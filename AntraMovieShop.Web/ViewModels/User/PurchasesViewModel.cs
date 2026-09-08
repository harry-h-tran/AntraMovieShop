using ApplicationCore.Model;

namespace AntraMovieShop.Web.ViewModels.User
{
    public class PurchasesViewModel
    {
        public Guid PurchaseNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public MovieCardModel MovieCard { get; set; }

    }
}
