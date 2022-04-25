using System.Collections.Generic;
namespace OvertimeRequest_API.Repository.Interface
{
    public class IRepository
    {
        IEnumerable<Entity> Get();
        Entity Get(Key key);
        int Insert(Entity entity);
        int Update(Entity entity);
        int Delete(Key key);
    }
}
