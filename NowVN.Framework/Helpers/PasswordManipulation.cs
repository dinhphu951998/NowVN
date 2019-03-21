using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NowVN.Framework.Helpers
{
    public class PasswordManipulation
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (String.IsNullOrEmpty(password)) throw new NowVNException();

            using (var encrypt = new HMACSHA256())
            {
                passwordSalt = encrypt.Key;
                passwordHash = encrypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] storedPasswordHash, byte[] storedPasswordSalt)
        {
            if (password == null) throw new NowVNException("Password is null.");
            if (string.IsNullOrWhiteSpace(password)) throw new NowVNException("Value cannot be empty or whitespace only string.");
            if (storedPasswordHash == null || storedPasswordHash.Length == 0) throw new NowVNException("Invalid length of password hash (64 bytes expected).");
            if (storedPasswordSalt == null || storedPasswordSalt.Length == 0) throw new NowVNException("Invalid length of password salt (128 bytes expected).");

            using (var encrypt = new HMACSHA256(storedPasswordSalt))
            {
                var passwordHash = encrypt.ComputeHash(Encoding.UTF8.GetBytes(password));
                
                for (int i = 0; i < storedPasswordHash.Length; i++)
                {
                    if (storedPasswordHash[i] != passwordHash[i])
                        return false;
                }
            }
            return true;
        }


    }
}
