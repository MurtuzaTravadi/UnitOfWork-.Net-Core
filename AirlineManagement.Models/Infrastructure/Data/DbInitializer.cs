using AirlineManagement.Models.Domain.Model;
using System;
using System.Linq;


namespace AirlineManagement.Models.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AirlineContext context)
        {
            context.Database.EnsureCreated();
            
            context.SaveChanges();
        }
    }
}