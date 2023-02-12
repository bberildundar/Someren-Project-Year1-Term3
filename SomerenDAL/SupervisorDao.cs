using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class SupervisorDao : BaseDao
    {
        private List<Supervisor> ReadTables(DataTable dataTable)
        {
            List<Supervisor> supervisors = new List<Supervisor>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new Supervisor()
                {
                    LecturerId = (int)dr["LecturerId"],
                    ActivityId = (int)dr["ActivityId"],
                };
                supervisors.Add(supervisor);
            }
            return supervisors;
        }

        public void Add(Supervisor supervisor)//register new supervisor
        {
            string query =
                "INSERT INTO [ActivitySupervisor] (LecturerID, ActivityID) " +
                "VALUES (@LecturerID, @ActivityID) SELECT SCOPE_IDENTITY()";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@LecturerID", supervisor.LecturerId),
                new SqlParameter("@ActivityID", supervisor.ActivityId)
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Remove(Supervisor supervisor)
        {
            string query = "DELETE FROM ActivitySupervisor WHERE LecturerID = @LecturerId and ActivityID = @ActivityId;";
            SqlParameter[] sqlParameters = {
                new SqlParameter("@LecturerId", supervisor.LecturerId),
                new SqlParameter("@ActivityId", supervisor.ActivityId)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
