using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        int RegisterUser(UserRegisterModel userRegisterModel);
        UserLoginResponseModel ValidateUser(UserLoginRequestModel userLoginModel);
    }
}
