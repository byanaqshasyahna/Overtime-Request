using OvertimeRequest_API.Context;
using OvertimeRequest_API.Models;

namespace OvertimeRequest_API.Repository.Data
{
    public class ActivityRepository : GeneralRepository<MyContext, Activity, int>
    {
        private readonly MyContext rContext;
        public ActivityRepository(MyContext myContext) : base(myContext)
        {
            rContext = myContext;
        }
    }
}
