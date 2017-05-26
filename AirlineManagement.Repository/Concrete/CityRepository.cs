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
    public class CityRepository : BaseRepository<City>, ICityRepository
    {

        //public CityRepository()
        //{

        //}

        public City Add(City model)
        {
            try
            {
                context.Add(model);
                context.SaveChanges();
                return model;
            }
            catch (Exception)
            {
                return model;
            }
        }

        public City CityExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.Citys.Find(id);
        }

        public bool CityExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.Citys.Any(a => a.Id == id);
        }

        public bool Delete(int id)
        {
            try
            {
                City oCity = context.Citys.Find(id);
                context.Remove(oCity);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public City Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                else
                    return context.Citys.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public City Get(int id)
        {
            try
            {
                return context.Citys.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<City> GetAll()
        {
            try
            {
                return context.Citys.ToList();
            }
            catch
            {
                return null;

            }
        }

        public City Update(City model)
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
    }
}
