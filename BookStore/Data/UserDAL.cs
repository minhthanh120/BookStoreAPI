using NHibernate;
using BookStore.Interfaces;
using BookStore.Models.Entities;
using ISession = NHibernate.ISession;
using BookStore.Models;
using System.Security.Cryptography;
using System.Text;
using BookStore.Ultilities;
using Microsoft.AspNetCore.Identity;

namespace BookStore.Data
{
    public class UserDAL : IUserService
    {
        private readonly UserManager<User> _userManager;
        public UserDAL()
        {
        }
        
        public async Task<bool> Login(UserLogin user)
        {

            bool result = false;
            string salt = "";
            try
            {
                using (ISession session = NhibernateSession.UserSession())
                {
                    UserLogin ul = new UserLogin();
                    salt = session.CreateSQLQuery("SELECT Salt from UserPassword where Account = :account").SetParameter("account", user.Account).ExecuteUpdate().ToString();
                    ul.Account = user.Account;
                    ul.Password = user.Password;
                    //session.get;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
        public async Task<bool> Register(UserRegister user)
        {
            bool result = false;
            result = true;
            using (ISession session = NhibernateSession.UserSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    session.Save(new User { Account = user.Account, Email = user.Email, Firstname = user.Firstname, Lastname = user.Lastname });
                    UserPassword up = new UserPassword();
                    up.Account = user.Account;
                    up.Password = user.Password;
                    up.Salt = GenSalt();
                    up.Hash_MD5 = HashPassword(up.Password, up.Salt);
                    session.Save(up);
                    tx.Commit();
                }
            }
            return result;
        }
        string GenSalt()
        {
            byte[] salt = new byte[16];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        string HashPassword(string password, string salt)
        {
            Console.WriteLine(salt);
            password += salt;
            var sha = SHA1.Create();
            Console.WriteLine(password);
            var bytearray = Encoding.UTF8.GetBytes(password);
            var hashed = sha.ComputeHash(bytearray);
            var result = Convert.ToBase64String(hashed);
            Console.WriteLine(result);
            return result;
        }
    }
}
