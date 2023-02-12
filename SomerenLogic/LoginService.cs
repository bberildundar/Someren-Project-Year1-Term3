using SomerenDAL;
using SomerenModel;
using System;

namespace SomerenLogic
{
    public class LoginService
    {
        LoginDao loginDao;

        public LoginService()
        {
            loginDao = new LoginDao();
        }

        public User CheckLogin(string UserName, string Password)
        {
            return loginDao.CheckLogin(UserName, Password);
        }

        public User GetSalt(string UserName)
        {
            User encryptionPassword = loginDao.GetSalt(UserName);
            
            if (encryptionPassword.Salt == null)
            {
                throw new Exception("Sorry, this account doesn't exist.");
            }
            return loginDao.GetSalt(UserName);
        }

        public User CheckUser(string UserName)
        {
            return loginDao.CheckUser(UserName);
        }

        public bool IsAdmin(string UserName)
        {
            User user = CheckUser(UserName);

            if (user.Role == false)
            {
                return false;
            }

            return user.Role == true;
        }
    }
}
