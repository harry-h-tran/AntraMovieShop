namespace ApplicationCore.Contracts.Services
{
    public interface ICryptoService
    {
        string GenerateSalt();
        string HashPassword(string password, string salt);
    }
}
