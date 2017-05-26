using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface ISeatManagementRepository : IBaseRepository<SeatManagement>
    {
        SeatManagement Get(int? id);
        SeatManagement SeatManagementExists(int? id);
        bool SeatManagementExistsBool(int? id);
    }
}
