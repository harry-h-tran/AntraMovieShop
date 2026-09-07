using ApplicationCore.Model;

namespace ApplicationCore.Contracts.Services
{
    public interface IUserService
    {
        int RegisterUser(UserRegisterModel userRegisterModel);
        UserLoginResponseModel ValidateUser(UserLoginRequestModel userLoginModel);
        PagedResultSet<MovieCardModel> GetAllPurchasesForUser(int userId, int pageSize = 30, int pageIndex = 1);
    }
}
