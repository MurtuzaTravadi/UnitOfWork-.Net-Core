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
    public class UserBookHistoryRepository : BaseRepository<UserBookHistory>, IUserBookHistoryRepository
    {
        public UserBookHistoryRepository()
        {

        }

        public UserBookHistory Add(UserBookHistory model)
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

        public UserBookHistory UserBookHistoryExists(int? id)
        {
            if (id == null)
                return null;
            else
                return context.UserBookHistorys.Find(id);
        }

        public bool UserBookHistoryExistsBool(int? id)
        {
            if (id == null)
                return false;
            else
                return context.UserBookHistorys.Any(a => a.Id == id);
        }

        public bool Delete(int id)
        {
            try
            {
                UserBookHistory oUserBookHistory = context.UserBookHistorys.Find(id);
                context.Remove(oUserBookHistory);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UserBookHistory Get(int? id)
        {
            try
            {
                if (id == null)
                {
                    return null;
                }
                else
                    return context.UserBookHistorys.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public UserBookHistory Get(int id)
        {
            try
            {
                return context.UserBookHistorys.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UserBookHistory> GetAll()
        {
            try
            {
                return context.UserBookHistorys.ToList();
            }
            catch
            {
                return null;

            }
        }

        public UserBookHistory Update(UserBookHistory model)
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
