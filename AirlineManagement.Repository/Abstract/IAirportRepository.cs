using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface IAirportRepository : IBaseRepository<Airport>
    {
        Airport Get(int? id);
        Airport AirportExists(int? id);
        bool AirportExistsBool(int? id);
    }
}
