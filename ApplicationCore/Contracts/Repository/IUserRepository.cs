using ApplicationCore.Entity;

namespace ApplicationCore.Contracts.Repository
{
    public interface IUserRepository : IRepository<Users>
    {
        Users? GetUsersByEmail(string email);
    }
}
