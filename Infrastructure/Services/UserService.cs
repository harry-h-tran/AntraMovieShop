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

        public UserService(IUserRepository userRepository, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
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
                DateOfBirth = userRegisterModel.DateOfBirth.ToDateTime(TimeOnly.MinValue),
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
    }
}
