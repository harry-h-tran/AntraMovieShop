using System.Security.Cryptography;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Infrastructure.Services
{
    public class CryptoService : ICryptoService
    {
        public string GenerateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public string HashPassword(string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltBytes,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }
    }
}
