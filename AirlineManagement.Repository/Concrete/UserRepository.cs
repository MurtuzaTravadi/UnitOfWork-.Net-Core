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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository()
        {

        }

        public User Add(User model)
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

        public User UserExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.Users.Find(id);
        }

        public bool UserExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.Users.Any(a => a.Id == id);
        }

        public bool Delete(int id)
        {
            try
            {
                User oUser = context.Users.Find(id);
                context.Remove(oUser);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public User Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                else
                    return context.Users.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User Get(int id)
        {
            try
            {
                return context.Users.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<User> GetAll()
        {
            try
            {
                return context.Users.ToList();
            }
            catch
            {
                return null;

            }
        }

        public User Update(User model)
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
