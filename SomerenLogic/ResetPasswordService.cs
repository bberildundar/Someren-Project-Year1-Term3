using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class ResetPasswordService
    {
        ResetPasswordDao renewPasswordDao;

        public ResetPasswordService()
        {
            renewPasswordDao = new ResetPasswordDao();
        }

        public User ReadUser(string username)
        {
            return renewPasswordDao.ReadUser(username);
        }

        public void UpdatePassword(User user)
        {
            renewPasswordDao.UpdatePassword(user);
        }
    }
}