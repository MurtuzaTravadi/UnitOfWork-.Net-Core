using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface IUserHotelBookRepository : IBaseRepository<UserHotelBook>
    {
        UserHotelBook Get(int? id);
        UserHotelBook UserHotelBookExists(int? id);
        bool UserHotelBookExistsBool(int? id);
    }
}
