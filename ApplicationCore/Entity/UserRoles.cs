namespace ApplicationCore.Entity
{
    public class UserRoles
    {
        public int RoleId { get; set; } = 1;
        public int UserId { get; set; }

        public Roles Role { get; set; } = null!;
        public Users User { get; set; } = null!;
    }
}
