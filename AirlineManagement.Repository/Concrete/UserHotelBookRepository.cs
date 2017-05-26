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
    public class UserHotelBookRepository : BaseRepository<UserHotelBook>, IUserHotelBookRepository
    {
        public UserHotelBookRepository()
        {

        }

        public UserHotelBook Add(UserHotelBook model)
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

        public UserHotelBook UserHotelBookExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.UserHotelBooks.Find(id);
        }

        public bool UserHotelBookExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.UserHotelBooks.Any(a => a.Id == id);
        }

        public bool Delete(int id)
        {
            try
            {
                UserHotelBook oUserHotelBook = context.UserHotelBooks.Find(id);
                context.Remove(oUserHotelBook);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserHotelBook Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                else
                    return context.UserHotelBooks.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UserHotelBook Get(int id)
        {
            try
            {
                return context.UserHotelBooks.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UserHotelBook> GetAll()
        {
            try
            {
                return context.UserHotelBooks.ToList();
            }
            catch
            {
                return null;

            }
        }

        public UserHotelBook Update(UserHotelBook model)
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
