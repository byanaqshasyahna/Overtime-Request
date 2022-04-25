using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
namespace OvertimeRequest_API.Repository.Data
{
    public class EmployeeOvertimeRepository : GeneralRepository<MyContext, EmployeeOvertime, string>
    {
        private readonly MyContext eoContext;
        public EmployeeOvertimeRepository(MyContext myContext) : base(myContext)
        {
            eoContext = myContext;
        }
    }
}
