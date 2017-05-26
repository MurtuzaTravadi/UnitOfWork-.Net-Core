using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineManagementSystem.Abstract;
using Microsoft.EntityFrameworkCore;
using AirlineManagement.Models.Infrastructure.Data;
using AirlineManagement.Models.Domain.Model;
using AirlineManagement.Repository;

namespace IndiaAirlineManagementSystem.Repository
{
    public class AirlineRepository : IAirlineRepository
    {

        //protected readonly AirlineContext _dbContext;

        //public AirlineRepository(AirlineContext context)
        //{
        //    this._dbContext = context;
        //}

        AirlineContext _dbContext;

        public AirlineRepository(AirlineContext context)
        {
            _dbContext = context;
        }

        public Airline Add(Airline model)
        {
            try
            {
                _dbContext.Add(model);
                _dbContext.SaveChanges();
                return model;
            }
            catch(Exception)
            {
                return model;
            }
        }

        public Airline AirlineExists(int? id)
        {
            if (id == null)
                return null;
            else
                return _dbContext.Airlines.Find(id);
        }

        public bool Delete(int id)
        {
            try
            {
                Airline oAirline = _dbContext.Airlines.Find(id);
                _dbContext.Remove(oAirline);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Airline Get(int id)
        {
            try
            {
                return _dbContext.Airlines.Find(id);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Airline Get(int? id)
        {
            try
            {
                if(id == null)
                {
                    return null;
                }
                else
                return _dbContext.Airlines.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Airline> GetAll()
        {
            try
            {
                return _dbContext.Airlines.ToList();
            }
            catch
            {
                return null;

            }

        }

        public Airline Update(Airline model)
        {
            try
            {
                _dbContext.Entry(model).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return model;
            }
            catch
            {
                return null;
            }
        }

        bool IAirlineRepository.AirlineExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return _dbContext.Airlines.Any(a => a.Id == id);
        }
    }
}
