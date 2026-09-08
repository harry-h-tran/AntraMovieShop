using System.Security.Claims;
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }

            var purchases = _userService.GetAllPurchasesForUser(int.Parse(userId));
            return View(purchases);
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
