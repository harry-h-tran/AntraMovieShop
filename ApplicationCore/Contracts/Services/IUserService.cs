using ApplicationCore.Entity;
using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        User RegisterUser(UserRegisterModel userRegisterModel);
        User ValidateUser(UserLoginModel userLoginModel);
    }
}
