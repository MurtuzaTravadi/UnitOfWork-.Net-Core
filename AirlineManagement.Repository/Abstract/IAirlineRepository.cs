using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface IAirlineRepository : IBaseRepository<Airline>
    {
        Airline Get(int? id);
        Airline AirlineExists(int? id);
        bool AirlineExistsBool(int? id);
    }
}
