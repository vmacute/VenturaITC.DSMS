using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VenturaITC.Security
{
    public class Authentication
    {
        /// <summary>
        /// Hashs a password using the SHA-256 algoritm.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>The SHA-256 hash of the given username and password</returns>
        /// <remarks>The final user's password is based on the concatenaion of the  username and password.</remarks>
        public static byte[] HashPassword(string password)
        {
            try
            {
                SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
                return sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Verifies the user's password.
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="userPassword">The user's password.</param>
        /// <param name="storedPassword">The user's password byte array stored for example in the database.</param>
        /// <returns>true if the given user's passwords and that one stored in the database are equal, otherwise false.</returns>
        public static bool VerifyPassword(string password, byte[] storedPassword)
        {
            try
            {
                byte[] userPassword = HashPassword(password);

                if (userPassword.Length != storedPassword.Length)
                {
                    return false;
                }

                for (int i = 0; i < userPassword.Length; i++)
                {
                    if (userPassword[i] != storedPassword[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the maximum login attempts.
        /// </summary>
        /// <returns>The maximum login attempts</returns>
        public static int GetMaxLoginAttempts()
        {
            return 3;
        }

        /// <summary>
        /// Gets the minimum password length.
        /// </summary>
        /// <returns>The minimum password length.</returns>
        public static int GetMinPasswordLength()
        {
            return 8;
        }

        /// <summary>
        /// Gets the password's life time.
        /// </summary>
        /// <returns>The password's life time.</returns>
        /// <remarks>The password's life time is given in days.</remarks>
        public static int GetPasswordLifeTime()
        {
            return 30;
        }
    }

}

