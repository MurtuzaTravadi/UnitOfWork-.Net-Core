using AirlineManagementSystem.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagement.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAirlineRepository AirlineRepository { get; }
        IAirportRepository AirportRepository { get; }

        int SaveChanges();
    }
}
