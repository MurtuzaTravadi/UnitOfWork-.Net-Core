using AirlineManagement.Models.Domain.Model;
using AirlineManagement.Models.Infrastructure.Data;
using AirlineManagementSystem.Abstract;
using IndiaAirlineManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirlineManagement.Repository
{
    public partial class UnitOfWork : IUnitOfWork
    {
        // public IAirlineRepository AirlineRepository => new AirlineRepository();
        private AirlineContext context;
        private AirlineRepository _airlineRepository;
        private AirportRepository _airportRepository;

        public UnitOfWork(AirlineContext context)
        {
            this.context = context ?? throw new ArgumentNullException("Context was not supplied");
        }

        public IAirlineRepository AirlineRepository
        {
            get
            {
                if (_airlineRepository == null)
                {
                    _airlineRepository = new AirlineRepository(context);
                }

                return _airlineRepository;
            }
        }

        public IAirportRepository AirportRepository
        {
            get
            {
                if (_airportRepository == null)
                {
                    _airportRepository = new AirportRepository(context);
                }

                return _airportRepository;
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public int SaveChanges()
        {
            return context.SaveChanges();
        }
    }
}
