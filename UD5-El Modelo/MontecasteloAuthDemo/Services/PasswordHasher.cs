using System.Security.Cryptography;

namespace MontecasteloAuthDemo.Services
{
    public static class PasswordHasher
    {
        private const int Iterations = 150_000;
        private const int SaltSize = 16; // 128 bits
        private const int KeySize  = 32; // 256 bits

        public static string CreateSalt()
            => Convert.ToBase64String(RandomNumberGenerator.GetBytes(SaltSize));

        public static string HashPassword(string password, string base64Salt)
        {
            var salt = Convert.FromBase64String(base64Salt);
            var key = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);
            return Convert.ToBase64String(key);
        }

        public static bool Verify(string password, string base64Salt, string expectedBase64Hash)
            => HashPassword(password, base64Salt) == expectedBase64Hash;
    }
}
