using System.Text;
using System.Security;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace BookStore.Ultilities
{
    public class EncrypePassword
    {
        public static string Hash_MD5(string password, byte[] salt)
        {
            string encryped = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password = password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 1000,
                numBytesRequested: 256 / 8));
            Console.WriteLine(encryped);
            return encryped ;
        }
        
    }
}
