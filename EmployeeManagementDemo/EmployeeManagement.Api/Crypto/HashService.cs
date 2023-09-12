using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Crypto
{
    public class HashService : IHashService
    {
        private int saltLengthLimit = 32;

        public HashService()
        {

        }
        public UserAuth SaltAndHashPassword(string password, string salt)
        {
            var saltAsBytes = Encoding.UTF8.GetBytes(salt);
            var textAsBytes = Encoding.UTF8.GetBytes(password);

            var textWithSaltBytes = new List<byte>();
            textWithSaltBytes.AddRange(textAsBytes);
            textWithSaltBytes.AddRange(saltAsBytes);

            var hasher = SHA256.Create();

            var hashed = hasher.ComputeHash(textWithSaltBytes.ToArray());

            var userAuth = new UserAuth
            {
                Password = Convert.ToBase64String(hashed),
                Salt = salt
            };

            return userAuth;
        }
        public UserAuth GenerateSaltedPasswordHash(string password)
        {
            var saltAsBytes = GetSalt(saltLengthLimit);
            var textAsBytes = Encoding.UTF8.GetBytes(password);

            var textWithSaltBytes = new List<byte>();
            textWithSaltBytes.AddRange(textAsBytes);
            textWithSaltBytes.AddRange(saltAsBytes);

            var hasher = SHA256.Create();

            var hashed = hasher.ComputeHash(textWithSaltBytes.ToArray());

            return new UserAuth
            {
                Password = Convert.ToBase64String(hashed),
                Salt = Convert.ToBase64String(saltAsBytes.ToArray())
            };

        }

        private byte[] GetSalt(int maximumSaltLength)
        {
            var salt = new byte[maximumSaltLength];
            using (var random = new RNGCryptoServiceProvider())
            {
                random.GetNonZeroBytes(salt);
            }

            return salt;
        }

    }
}
