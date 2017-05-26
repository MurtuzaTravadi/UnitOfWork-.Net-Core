using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface ITransectionRepository : IBaseRepository<Transection>
    {
        Transection Get(int? id);
        Transection TransectionExists(int? id);
        bool TransectionExistsBool(int? id);
    }
}
