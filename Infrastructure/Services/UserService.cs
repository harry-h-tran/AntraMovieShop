using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly IPurchaseRepository _purchaseRepository;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService,
            IPurchaseRepository purchaseRepository)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _purchaseRepository = purchaseRepository;
        }
        public int RegisterUser(UserRegisterModel userRegisterModel)
        {
            var existingUser = _userRepository.GetUsersByEmail(userRegisterModel.Email);
            if (existingUser != null)
            {
                // TODO: Implement Result Pattern: to return a meaningful error message instead of just returning -1
                return -1;
            }

            string salt = _cryptoService.GenerateSalt();
            string hashedPassword = _cryptoService.HashPassword(userRegisterModel.Password, salt);

            Users newUser = new Users
            {
                FirstName = userRegisterModel.FirstName,
                LastName = userRegisterModel.LastName,
                DateOfBirth = userRegisterModel.DateOfBirth.Date,
                Email = userRegisterModel.Email,
                HashedPassword = hashedPassword,
                Salt = salt,
                IsLocked = false,
            };
            newUser.UserRoles = new UserRoles
            {
                RoleId = 1 // Default role
            };

            int rowsAffected = _userRepository.Insert(newUser);
            if (rowsAffected > 0) // Checking > 0 handles cases where child rows are inserted as well
            {
                return newUser.Id;
            }

            // TODO: Implement Result Pattern: to return a meaningful error message instead of just returning 0
            // 
            return 0;

        }

        public UserLoginResponseModel? ValidateUser(UserLoginRequestModel userLoginModel)
        {
            var existingUser = _userRepository.GetUsersByEmail(userLoginModel.Email);
            if (existingUser == null)
            {
                // TODO: Implement Result Pattern: to return a meaningful error message instead of just returning null
                // No user Exists with the provided email
                return null;
            }

            string userSalt = existingUser.Salt;
            string hashedPassword = _cryptoService.HashPassword(userLoginModel.Password, userSalt);

            if (hashedPassword == existingUser.HashedPassword)
            {
                return new UserLoginResponseModel
                {
                    Id = existingUser.Id,
                    FirstName = existingUser.FirstName,
                    LastName = existingUser.LastName,
                    Email = existingUser.Email,
                    RoleId = existingUser.UserRoles.RoleId
                };
            }

            // TODO: Implement Result Pattern: to return a meaningful error message instead of just returning null
            // Incorrect password
            return null;
        }

        public PagedResultSet<UserPurchasesModel> GetAllPurchasesForUser(int userId, int pageSize = 30, int pageIndex = 1)
        {
            var purchases = _purchaseRepository.GetPurchasesByUserId(userId, pageSize, pageIndex);
            var purchasedMoviesCards = purchases.results.Select(purchase => new UserPurchasesModel
            {
                PurchaseNumber = purchase.PurchaseNumber,
                Price = purchase.TotalPrice,
                PurchaseDate = purchase.PurchaseDateTime.Date,
                MovieCard = new MovieCardModel
                {
                    Id = purchase.Movie.Id,
                    Title = purchase.Movie.Title,
                    PosterUrl = purchase.Movie.PosterUrl
                }
            }).ToList();

            return new PagedResultSet<UserPurchasesModel>
            {
                results = purchasedMoviesCards,
                PageIndex = purchases.PageIndex,
                PageSize = purchases.PageSize,
                TotalPages = purchases.TotalPages,
                TotalResults = purchases.TotalResults
            };
        }
    }
}
