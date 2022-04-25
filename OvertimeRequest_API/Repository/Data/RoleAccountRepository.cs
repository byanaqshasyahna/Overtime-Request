using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
namespace OvertimeRequest_API.Repository.Data
{
    public class RoleAccountRepository : GeneralRepository<MyContext, RoleAccount, string>
    {
        private readonly MyContext arContext;

        public RoleAccountRepository(MyContext myContext) : base(myContext)
        {
            arContext = myContext;
        }
    }
}
