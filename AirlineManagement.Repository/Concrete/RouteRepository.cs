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
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository()
        {

        }

        public Route Add(Route model)
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

        public Route RouteExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.Routes.Find(id);
        }

        public bool RouteExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.Routes.Any(a => a.Id == id);
        }

        public bool Delete(int id)
        {
            try
            {
                Route oRoute = context.Routes.Find(id);
                context.Remove(oRoute);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Route Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                else
                    return context.Routes.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Route Get(int id)
        {
            try
            {
                return context.Routes.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Route> GetAll()
        {
            try
            {
                return context.Routes.ToList();
            }
            catch
            {
                return null;

            }
        }

        public Route Update(Route model)
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
