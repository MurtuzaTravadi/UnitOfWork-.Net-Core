using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirlineManagementSystem.Abstract;
using Microsoft.EntityFrameworkCore;
using AirlineManagement.Models.Infrastructure.Data;
using AirlineManagement.Models.Domain.Model;

namespace IndiaAirlineManagementSystem.Repository
{
    public class AirportRepository : BaseRepository<Airport>, IAirportRepository
    {
        public AirportRepository(AirlineContext context)
        {
            this.context = context;
        }

        public Airport Add(Airport model)
        {
            try
            {
                context.Add(model);
                context.SaveChanges();
                return model;
            }
            catch(Exception)
            {
                return model;
            }
        }

        public Airport AirlineExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.Airports.Find(id);
        }

        public Airport AirportExists(int? id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            try
            {
                Airport oAirline = context.Airports.Find(id);
                context.Remove(oAirline);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Airport Get(int id)
        {
            try
            {
                return context.Airports.Find(id);
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Airport Get(int? id)
        {
            try
            {
                if(id == null)
                {
                    return null;
                }
                else
                return context.Airports.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Airport> GetAll()
        {
            try
            {
                return context.Airports.ToList();
            }
            catch
            {
                return null;

            }

        }

        public Airport Update(Airport model)
        {
            try
            {
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return model;
            }
            catch
            {
                return null;
            }
        }

       
        bool IAirportRepository.AirportExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.Airports.Any(a => a.Id == id);
        }
    }
}
