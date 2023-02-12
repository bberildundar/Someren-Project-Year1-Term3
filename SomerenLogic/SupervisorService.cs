using System.Collections.Generic;
using SomerenDAL;
using SomerenModel;

namespace SomerenLogic
{
    public class SupervisorService
    {
        SupervisorDao supervisordb;

        public SupervisorService()
        {
            supervisordb = new SupervisorDao();
        }

        public void AddSupervisor(Supervisor supervisor)
        {
            supervisordb.Add(supervisor);
        }

        public void RemoveSupervisor(Supervisor supervisor)
        {
            supervisordb.Remove(supervisor);
        }
    }
}
