using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;

namespace OvertimeRequest_API.Repository.Data
{
    public class RoleRepository : GeneralRepository<MyContext, Role, string>
    {
        private readonly MyContext rContext;
        public RoleRepository(MyContext myContext) : base(myContext)
        {
            rContext = myContext;
        }
    }
}
