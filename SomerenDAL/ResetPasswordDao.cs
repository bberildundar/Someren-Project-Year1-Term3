using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class ResetPasswordDao : BaseDao
    {
        public User ReadUser(string UserName)
        {
            string query = "SELECT Username, SecretQuestion, SecretAnswer FROM Users " +
                "WHERE Username=@Username";

            SqlParameter[] dateParameters =
            {
                new SqlParameter("@Username", UserName),
            };
            return ReadUserData(ExecuteSelectQuery(query, dateParameters));
        }

        private User ReadUserData(DataTable dataTable)
        {
            User userData = new User();
            foreach (DataRow dr in dataTable.Rows)
            {
                userData.UserName = RemoveWhitespace((string)dr["Username"]);
                userData.SecretQuestion = RemoveWhitespace((string)dr["SecretQuestion"]);
                userData.SecretAnswer = RemoveWhitespace((string)dr["SecretAnswer"]);
            }
            return userData;
        }

        public void UpdatePassword(User user)
        {
            string query = "UPDATE [Users] SET SecretQuestion=@SecretQuestion, SecretAnswer=@SecretAnswer ," +
                "HashedPassword = @HashedPassword, Salt = @Salt WHERE Username = @Username";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@HashedPassword", user.HashedPassword),
                new SqlParameter("@Salt", user.Salt),
                new SqlParameter("@Username", user.UserName),
                new SqlParameter("@SecretQuestion", user.SecretQuestion),
                new SqlParameter("@SecretAnswer", user.SecretAnswer),
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public string RemoveWhitespace(string text)
        {
            return text.Replace(" ", "");
        }
    }
}