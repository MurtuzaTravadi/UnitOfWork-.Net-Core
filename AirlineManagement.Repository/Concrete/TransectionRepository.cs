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
    public class TransectionRepository : BaseRepository<Transection>, ITransectionRepository
    {
        public TransectionRepository()
        {

        }

        public Transection Add(Transection model)
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

        public Transection TransectionExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.Transections.Find(id);
        }

        public bool TransectionExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.Transections.Any(a => a.Id == id);
        }

        public bool Delete(int id)
        {
            try
            {
                Transection oTransection = context.Transections.Find(id);
                context.Remove(oTransection);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Transection Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                else
                    return context.Transections.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Transection Get(int id)
        {
            try
            {
                return context.Transections.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Transection> GetAll()
        {
            try
            {
                return context.Transections.ToList();
            }
            catch
            {
                return null;

            }
        }

        public Transection Update(Transection model)
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
