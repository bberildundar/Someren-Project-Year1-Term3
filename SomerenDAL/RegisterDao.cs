using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SomerenModel;
using System.Data;

namespace SomerenDAL
{
    public class RegisterDao : BaseDao
    {
        public void Add(User user)
        {
            string query =
                "INSERT INTO [Users] ([Name], [Username], [Role], [HashedPassword], [Salt], [SecretQuestion], [SecretAnswer])" +
                "VALUES (@Name, @Username, @Role, @HashedPassword, @Salt, @SecretQuestion, @SecretAnswer) SELECT SCOPE_IDENTITY()";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@Name", user.Name),
                new SqlParameter("@Username", user.UserName),
                new SqlParameter("@Role", user.Role),
                new SqlParameter("@HashedPassword", user.HashedPassword),
                new SqlParameter("@Salt", user.Salt),
                new SqlParameter("@SecretQuestion", user.SecretQuestion),
                new SqlParameter("@SecretAnswer", user.SecretAnswer)
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public List<string> GetAllUsernames()
        {
            string query = "SELECT Username FROM [Users]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadUsernames(ExecuteSelectQuery(query, sqlParameters));
        }

        public List<string> ReadUsernames(DataTable dataTable)
        {
            List<string> usernames = new List<string>();

            foreach (DataRow dr in dataTable.Rows)
            {
                string username = (string)dr["Username"];
                
                usernames.Add(username);
            }
            return usernames;
        }

    }
}
