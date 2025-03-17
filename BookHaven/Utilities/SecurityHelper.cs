using System;
using System.Security.Cryptography;
using System.Text;

namespace BookHaven.Utilities
{
    public static class SecurityHelper
    {
        // Generate a salt for password hashing
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        // Hash a password with the given salt
        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        // Verify a password against a stored hash and salt
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            string computedHash = HashPassword(password, storedSalt);
            return computedHash == storedHash;
        }
    }
}
