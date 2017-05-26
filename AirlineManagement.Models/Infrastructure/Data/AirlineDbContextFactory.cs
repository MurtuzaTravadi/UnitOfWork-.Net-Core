using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace AirlineManagement.Models.Infrastructure.Data
{
    public class AirlineDbContextFactory : IDbContextFactory<AirlineContext>
    {
        public AirlineContext Create(DbContextFactoryOptions options)
        {
            var builder = new DbContextOptionsBuilder<AirlineContext>();
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NewAirlineManagemntOne;Integrated Security=True;");
            return new AirlineContext(builder.Options);
        }
    }
}
