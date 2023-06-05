using System.Security.Cryptography;

namespace AssetTrackerApi.Tools
{
    public static class PasswordUtility
    {
        public static KeyValuePair<string, string> HashPassword(string password)
        {
            string salt = CreateSalt();
            var key = new Rfc2898DeriveBytes(password, System.Text.Encoding.UTF8.GetBytes(salt), 10000, HashAlgorithmName.SHA512);
            byte[] hash = key.GetBytes(64);  // 64-byte hash

            return new KeyValuePair<string, string>(Convert.ToBase64String(hash), salt);
        }

        private static string CreateSalt()
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(64);

            return Convert.ToBase64String(saltBytes);
        }

        public static bool VerifyPassword(string providedPassword, string storedHash, string storedSalt)
        {
            // Hash the provided password with the stored salt
            var pbkdf2 = new Rfc2898DeriveBytes(providedPassword, System.Text.Encoding.UTF8.GetBytes(storedSalt), 10000, HashAlgorithmName.SHA512);
            byte[] hashedPassword = pbkdf2.GetBytes(20);  // 20-byte hash

            // Convert the hashed password to a Base64 string
            string hashedPasswordString = Convert.ToBase64String(hashedPassword);

            // Compare the hashed password with the stored hash
            return hashedPasswordString == storedHash;
        }
    }
}
