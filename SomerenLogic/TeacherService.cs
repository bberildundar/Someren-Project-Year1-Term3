using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenLogic
{
     public class TeacherService
    {
        TeachersDao teacherdb;

        public TeacherService()
        {
            teacherdb = new TeachersDao();
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = teacherdb.GetAllTeachers();
            return teachers;
        }

        public List<Teacher> GetSupervisor(Activity activity)
        {
            List<Teacher> teachers = teacherdb.GetSupervisor(activity);
            return teachers;
        }

        public List<Teacher> GetNonSupervisor(Activity activity)
        {
            List<Teacher> teachers = teacherdb.GetNonSupervisor(activity);
            return teachers;
        }

    }
}
