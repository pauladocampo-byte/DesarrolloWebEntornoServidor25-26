using System.Security.Cryptography;

namespace CineMontecasteloMvc.Helpers
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;
        private const char Delimiter = '.';

        public static string HashPassword(string password)
        {
            using var rng = RandomNumberGenerator.Create();
            var salt = new byte[SaltSize];
            rng.GetBytes(salt);

            var hash = PBKDF2(password, salt, Iterations, KeySize);
            return string.Join(Delimiter, Iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(storedHash)) return false;

            var parts = storedHash.Split(Delimiter);
            if (parts.Length != 3) return false;
            if (!int.TryParse(parts[0], out var iterations)) return false;

            var salt = Convert.FromBase64String(parts[1]);
            var hash = Convert.FromBase64String(parts[2]);

            var testHash = PBKDF2(password, salt, iterations, hash.Length);

            uint diff = (uint)hash.Length ^ (uint)testHash.Length;
            for (int i = 0; i < hash.Length && i < testHash.Length; i++)
                diff |= (uint)(hash[i] ^ testHash[i]);

            return diff == 0;
        }

        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}
