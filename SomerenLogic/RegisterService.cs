using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class RegisterService
    {
        RegisterDao registerdb;

        public RegisterService()
        {
            registerdb = new RegisterDao();
        }

        public void AddUser(User user)
        {
            registerdb.Add(user);
        }

        public List<string> GetUserNames()
        {
            List<string> usernames = registerdb.GetAllUsernames();
            return usernames;
        }

    }
}
