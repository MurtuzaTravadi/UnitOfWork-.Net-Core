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
    public class SeatManagementRepository : BaseRepository<SeatManagement>, ISeatManagementRepository
    {
        public SeatManagementRepository()
        {

        }

        public SeatManagement Add(SeatManagement model)
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

        public SeatManagement SeatManagementExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.SeatManagements.Find(id);
        }

        public bool SeatManagementExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.SeatManagements.Any(a => a.Id == id);
        }

        public bool Delete(int id)
        {
            try
            {
                SeatManagement oSeatManagement = context.SeatManagements.Find(id);
                context.Remove(oSeatManagement);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public SeatManagement Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                else
                    return context.SeatManagements.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public SeatManagement Get(int id)
        {
            try
            {
                return context.SeatManagements.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<SeatManagement> GetAll()
        {
            try
            {
                return context.SeatManagements.ToList();
            }
            catch
            {
                return null;

            }
        }

        public SeatManagement Update(SeatManagement model)
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
