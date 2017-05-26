using System;
using System.Collections.Generic;
using AirlineManagement.Models.Infrastructure.Data;
using AirlineManagementSystem.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IndiaAirlineManagementSystem.Repository
{ 
    public abstract class BaseRepository<T> : IBaseRepository<T> where T :class  
    {
        public AirlineContext context;
        //public DbSet<T> dbset;

        //public BaseRepository(AirlineContext context)
        //{
        //    this.context = context;
        //    dbset = context.Set<T>();
        //}

        public T Add(T model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            //return dbset;
            return null;
        }


        public void ReloadAll()
        {
            foreach (var entity in context.ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        public T Update(T model)
        {
            throw new NotImplementedException();
        }
    }
}
