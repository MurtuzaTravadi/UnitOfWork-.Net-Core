using AirlineManagement.Models.Domain.Model;

namespace AirlineManagementSystem.Abstract
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Get(int? id);
        User UserExists(int? id);
        bool UserExistsBool(int? id);
    }
}
