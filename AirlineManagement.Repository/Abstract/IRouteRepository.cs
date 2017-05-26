using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface IRouteRepository : IBaseRepository<Route>
    {
        Route Get(int? id);
        Route RouteExists(int? id);
        bool RouteExistsBool(int? id);
    }
}
