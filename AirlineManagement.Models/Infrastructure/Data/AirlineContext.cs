using AirlineManagement.Models.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagement.Models.Infrastructure.Data
{
    public class AirlineContext : DbContext
    {
        

        public AirlineContext(DbContextOptions<AirlineContext> options) : base(options)
        {
        }



        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<SeatManagement> SeatManagements { get; set; }
        public DbSet<Transection> Transections { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBookHistory> UserBookHistorys { get; set; }
        public DbSet<UserHotelBook> UserHotelBooks { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Airline>().ToTable("Airline");
            modelBuilder.Entity<Route>().ToTable("Route");
            modelBuilder.Entity<Airport>().ToTable("Airport");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<SeatManagement>().ToTable("SeatManagement");
            modelBuilder.Entity<Transection>().ToTable("Transection");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<UserBookHistory>().ToTable("UserBookHistory");
            modelBuilder.Entity<UserHotelBook>().ToTable("UserHotelBook");
        }
    }
}