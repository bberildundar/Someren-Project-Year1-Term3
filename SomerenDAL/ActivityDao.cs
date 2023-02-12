
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SomerenModel;
using System.Data;

namespace SomerenDAL
{

    public class ActivityDao : BaseDao
    {
        public List<Activity> GetAllActivities()
        {
            string query = "SELECT ActivityId, ActivityName, ActivityDateTime, ActivityEndDateTime FROM [Activities]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activity> ReadTables(DataTable dataTable)
        {
            List<Activity> activities = new List<Activity>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activity activity = new Activity()
                {
                    ActivityId = (int)dr["ActivityId"],
                    ActivityName = (string)dr["ActivityName"],
                    ActivityDateTime = (DateTime)dr["ActivityDateTime"],
                    ActivityEndDateTime = (DateTime)dr["ActivityEndDateTime"]
                };
                activities.Add(activity);
            }
            return activities;
        }

        public void Add(Activity activity)
        {
            string query =
                "INSERT INTO [Activities] (ActivityName, ActivityDateTime, ActivityEndDateTime)" +
                "VALUES (@ActivityName, @ActivityDateTime, @ActivityEndDateTime) SELECT SCOPE_IDENTITY()";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ActivityName", activity.ActivityName),
                new SqlParameter("@ActivityDateTime", activity.ActivityDateTime),
                new SqlParameter("@ActivityEndDateTime", activity.ActivityEndDateTime)
            };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Remove(Activity activity)
        {
            string query = "DELETE FROM Activities WHERE ActivityId = @ActivityId";
            SqlParameter[] sqlParameters = { new SqlParameter("@ActivityId", activity.ActivityId) };

            ExecuteEditQuery(query, sqlParameters);
        }

        public void Change(Activity activity)
        {
            string query = "UPDATE [Activities] SET ActivityName = @ActivityName, ActivityDateTime = @ActivityDateTime, ActivityEndDateTime = @ActivityEndDateTime" +
                " WHERE ActivityId = @ActivityId";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@ActivityId", activity.ActivityId),
                new SqlParameter("@ActivityName", activity.ActivityName),
                new SqlParameter("@ActivityDateTime", activity.ActivityDateTime),
                new SqlParameter("@ActivityEndDateTime", activity.ActivityEndDateTime)
            };

            ExecuteEditQuery(query, sqlParameters);
        }
    }

}

