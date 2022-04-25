using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;

namespace OvertimeRequest_API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext aContext;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            aContext = myContext;
        }
    }
}
