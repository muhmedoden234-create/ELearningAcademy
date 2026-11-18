using System.Security.Cryptography;

namespace ELearningAcademy.Helpers
{
    public static class PasswordHasher
    {
        private const string Algorithm = "PBKDF2-SHA256";
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 100_000;

        public static string Hash(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] key = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, KeySize);

            return string.Join("$",
                Algorithm,
                Iterations.ToString(),
                Convert.ToBase64String(salt),
                Convert.ToBase64String(key));
        }

        public static bool Verify(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
                return false;

            string[] parts = storedHash.Split('$');
            if (parts.Length != 4 || parts[0] != Algorithm)
                return false;

            try
            {
                int iterations = int.Parse(parts[1]);
                byte[] salt = Convert.FromBase64String(parts[2]);
                byte[] expectedKey = Convert.FromBase64String(parts[3]);

                byte[] actualKey = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations,
                    HashAlgorithmName.SHA256, expectedKey.Length);

                return CryptographicOperations.FixedTimeEquals(actualKey, expectedKey);
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
