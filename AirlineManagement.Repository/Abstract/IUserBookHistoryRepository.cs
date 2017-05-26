using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface IUserBookHistoryRepository : IBaseRepository<UserBookHistory>
    {
        UserBookHistory Get(int? id);
        UserBookHistory UserBookHistoryExists(int? id);
        bool UserBookHistoryExistsBool(int? id);
    }
}
