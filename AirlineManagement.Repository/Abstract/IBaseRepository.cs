using System.Collections.Generic;
using System.Linq;

namespace AirlineManagementSystem.Abstract
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T Get(int id);
        T Add(T model);
        T Update(T model);
        bool Delete(int id);
    }
}
