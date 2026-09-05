using ApplicationCore.Contracts.Services;
using ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace AntraMovieShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(userLogin);
            }

            var user = _userService.ValidateUser(userLogin);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(userLogin);
            }

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterModel);
            }

            var createdUser = _userService.RegisterUser(userRegisterModel);
            if (createdUser == null)
            {
                ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                return View(userRegisterModel);
            }

            return RedirectToAction(nameof(Login));
        }
    }
}
