namespace ApplicationCore.Entity
{
    public class Roles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRoles UserRoles { get; set; } = null!;
    }
}
