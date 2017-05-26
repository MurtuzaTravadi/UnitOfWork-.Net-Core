using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface ICityRepository : IBaseRepository<City>
    {
        City Get(int? id);
        City CityExists(int? id);
        bool CityExistsBool(int? id);
    }
}
