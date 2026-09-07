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
                throw new InvalidOperationException("User with this email already exists.");
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
            throw new InvalidOperationException("Failed to register user.");
        }

        public Users ValidateUser(UserLoginModel userLoginModel)
        {
            throw new NotImplementedException();
        }
    }
}
