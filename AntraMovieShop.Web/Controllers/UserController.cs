using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace AntraMovieShop.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Purchases()
        {
            var MovieCards = _userService.GetAllPurchasesForUser(1);
            return View(MovieCards);
        }
        public IActionResult Account()
        {
            return View("NotImplemented");
        }
        public IActionResult Favorites()
        {
            return View("NotImplemented");
        }
    }
}
