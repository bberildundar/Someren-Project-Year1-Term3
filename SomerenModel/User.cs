using System;
using System.Security.Cryptography;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace SomerenModel
{
    public class User
    {
        private string userName;

        public string Name { get; set; } 
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                if (!IsValidEmail(userName))
                {
                    throw new Exception("Invalid E-mail");
                }
            }
        }
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public bool Role { get; set; }//0 : user, 1: admin
        public string HashedPassword { get; set; } //Hash password
        public string Salt { get; set; }


        public static string HashMethod(string Password, string Salt)
        {
            return ComputeHash(Encoding.UTF8.GetBytes(Password), Encoding.UTF8.GetBytes(Salt));
        }

        public static string ComputeHash(byte[] bytesToHash, byte[] salt)//get the hashpassword with the parameters(bytes,salt)
        {
            var byteResult = new Rfc2898DeriveBytes(bytesToHash, salt, 10000);
            return Convert.ToBase64String(byteResult.GetBytes(24));
        }

        public static string GenerateSalt()//It should be used only when new user sign up
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes);
        }

        public bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
