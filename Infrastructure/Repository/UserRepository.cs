using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        private readonly MovieShopDbContext _dbContext;

        public UserRepository(MovieShopDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public Users? GetUsersByEmail(string email)
        {
            return _dbContext.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .FirstOrDefault(u => u.Email == email);
        }
    }
}
