namespace ApplicationCore.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string HashedPassword { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public bool? IsLocked { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
