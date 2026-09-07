namespace ApplicationCore.Entity
{
    public class Users
    {
        public int Id { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public bool? IsLocked { get; set; }
        public string Salt { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }

        // Navigation properties
        public UserRoles UserRoles { get; set; } = null!;
        public ICollection<Reviews> Reviews { get; set; } = new List<Reviews>();
        public ICollection<Purchases> Purchases { get; set; } = new List<Purchases>();
    }
}
