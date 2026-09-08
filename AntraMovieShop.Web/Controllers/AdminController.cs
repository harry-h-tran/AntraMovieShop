using AntraMovieShop.Web.ViewModels.Admin;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AntraMovieShop.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult TopMovies(TopMoviesReportViewModel topMoviesRequest)
        {
            var movies = _adminService.GetTopMovies(topMoviesRequest.FromDate, topMoviesRequest.ToDate);
            var viewModel = new TopMoviesReportViewModel
            {
                FromDate = topMoviesRequest.FromDate,
                ToDate = topMoviesRequest.ToDate,
                PageIndex = movies.PageIndex,
                PageSize = movies.PageSize,
                TotalPages = movies.TotalPages,
                TopMovies = movies.results.ToList()
            };
            return View(viewModel);
        }
        public IActionResult CreateMovie()
        {
            return View("NotImplemented");
        }
    }
}
