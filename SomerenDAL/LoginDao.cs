using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class LoginDao : BaseDao
    {
        public User CheckLogin(string UserName, string HashedPassword)
        {
            string query = "SELECT Username FROM Users " +
                "WHERE Username=@Username AND [HashedPassword]=@Password";

            SqlParameter[] dateParameters =
            {
                new SqlParameter("@Username", UserName),
                new SqlParameter("@Password", HashedPassword),
            };
            return ReadLogin(ExecuteSelectQuery(query, dateParameters));
        }

        public User GetSalt(string UserName)
        {
            string query = "SELECT Salt from Users WHERE Username =@Username";

            SqlParameter[] dateParameter =
            {
                new SqlParameter("@Username",UserName)
            };
            return ReadSalt(ExecuteSelectQuery(query, dateParameter));
        }

        public User CheckUser(string UserName)
        {
            string query = "SELECT Username, Role " +
                "from Users " +
                "WHERE Username =@Username";

            SqlParameter[] dataParameter =
            {
                new SqlParameter("@Username",UserName)
            };
            return ReadUser(ExecuteSelectQuery(query, dataParameter));
        }

        private User ReadUser(DataTable dataTable)
        {
            User user = new User();

            foreach (DataRow dr in dataTable.Rows)
            {
                user.UserName = (string)dr["Username"];
                user.Role = (bool)dr["Role"];
            }
            return user;
        }
        private User ReadSalt(DataTable dataTable)
        {
            User encryption = new User();

            foreach (DataRow dr in dataTable.Rows)
            {
                encryption.Salt = (string)dr["Salt"];
            }
            return encryption;
        }

        private User ReadLogin(DataTable dataTable)
        {
            User login = new User();

            foreach (DataRow dr in dataTable.Rows)
            {
                login.UserName = (string)dr["Username"];
            }
            return login;
        }
    }
}
