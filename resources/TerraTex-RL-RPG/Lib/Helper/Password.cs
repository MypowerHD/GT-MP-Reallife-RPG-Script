using System;
using System.Text;

namespace TerraTex_RL_RPG.Lib.Helper
{
    class Password
    {
        public static string Hash(string password, string salt)
        {
            var bytes = new UTF8Encoding().GetBytes(salt + password);
            var hashBytes = System.Security.Cryptography.SHA512.Create().ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }

        public static string GenerateSalt()
        {
            int length = 128;
            string salt = "";
            const string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz-+.:;?&$!_";
            Random randomizer = new Random();
            
            for (int i = 0; i < length; i++)
            {
                salt += digits[randomizer.Next(digits.Length - 1)];
            }
            return salt;
        }
    }
}
