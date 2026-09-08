using ApplicationCore.Model;

namespace AntraMovieShop.Web.ViewModels.Admin
{
    public class TopMoviesReportViewModel
    {
        public List<TopMoviesModel> TopMovies { get; set; } = new List<TopMoviesModel>();
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 30;
        public int TotalPages { get; set; }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
    }
}
