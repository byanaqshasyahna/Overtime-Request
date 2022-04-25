using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;
namespace OvertimeRequest_API.Repository.Data
{
    public class OvertimeRepository : GeneralRepository<MyContext, Overtime, int>
    {
        private readonly MyContext oContext;
        public OvertimeRepository(MyContext myContext) : base(myContext)
        {
            oContext = myContext;
        }
    }
}
