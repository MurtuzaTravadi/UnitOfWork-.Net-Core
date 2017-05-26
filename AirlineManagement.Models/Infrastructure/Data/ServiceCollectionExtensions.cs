using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AirlineManagement.Models.Infrastructure.Data
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AirlineContext>(options =>
                    options.UseSqlServer(connectionString));
        }
    }
}
