using System;
using System.Security.Cryptography;

namespace SoftwareBase.Security
{
    /// <summary>
    /// Generates and validates hashed passwords
    /// </summary>
    public class PasswordHasher
    {
        /// <summary>
        /// Generates the Hashed password
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <returns>salt|interations|hash</returns>
        public string HashPassword(byte[] password)
        {
            byte[] salt = this.GenerateSalt();
            int interations = this.GenerateInterations();
            using Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, interations);
            byte[] hash = pbkdf2.GetBytes(32);
            return string.Format("{0}|{1}|{2}", Convert.ToBase64String(salt), interations, hash);
        }

        /// <summary>
        /// Validates password
        /// </summary>
        /// <param name="testPassword">Password to test</param>
        /// <param name="originalHashedData">The original hashed data</param>
        /// <returns>true if password is correct, otherwise false</returns>
        public bool IsValid(byte[] testPassword, string originalHashedData)
        {
            string[] originalHashedParts = originalHashedData.Split('|');
            byte[] originalSalt = Convert.FromBase64String(originalHashedParts[0]);
            int originalInterations = Int32.Parse(originalHashedParts[1]);
            byte[] originalHash = Convert.FromBase64String(originalHashedParts[2]);

            using Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(testPassword, originalSalt, originalInterations);
            byte[] testHash = pbkdf2.GetBytes(32);

            if (testHash == originalHash)
                return true;
            return false;
        }

        private byte[] GenerateSalt()
        {
            byte[] bytes = new byte[32];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }

        private int GenerateInterations()
        {
            Random rng = new Random();
            return rng.Next(10000, 25000);
        }
    }
}