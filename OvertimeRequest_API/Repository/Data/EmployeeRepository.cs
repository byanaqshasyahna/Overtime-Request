using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;

namespace OvertimeRequest_API.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext eContext;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            eContext = myContext;   
        }
    }
}
