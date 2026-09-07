using System.Security.Claims;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        public async Task<IActionResult> Login(UserLoginRequestModel userLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(userLogin);
            }

            var userLoginResponse = _userService.ValidateUser(userLogin);

            if (userLoginResponse == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password");
                return View(userLogin);
            }

            await CreateAuthCookie(
                userLoginResponse.Id,
                userLoginResponse.FirstName,
                userLoginResponse.LastName,
                userLoginResponse.Email,
                userLoginResponse.RoleId);
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
            if (createdUser == -1)
            {
                ModelState.AddModelError(string.Empty, $"Registration failed. Email already exists");
                return View(userRegisterModel);
            }
            if (createdUser == 0)
            {
                ModelState.AddModelError(string.Empty, $"Registration failed. (DB Write Error)");
                return View(userRegisterModel);
            }

            return RedirectToAction(nameof(Login));
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        private async Task CreateAuthCookie(int userId, string firstName, string lastName, string email, int roleId)
        {
            // Implementation for creating authentication cookie
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.GivenName, firstName),
                new Claim(ClaimTypes.Surname, lastName),
                new Claim(ClaimTypes.Role, roleId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                authProperties);
        }
    }
}
