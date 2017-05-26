using AirlineManagement.Models.Infrastructure.Data;
using AirlineManagement.Repository;
using AirlineManagementSystem.Abstract;
using IndiaAirlineManagementSystem.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace AirlineManagement
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            
            services.AddApplicationInsightsTelemetry(Configuration);

            //services.AddDbContext<AirlineContext>(options =>
            //            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddEntityFramework(Configuration.GetConnectionString("DefaultConnection"));
            services.AddScoped<AirlineContext, AirlineContext>();
            services.AddTransient<IAirlineRepository, AirlineRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            ////services.AddTransient<IAirportRepository, AirportRepository>();
            //services.AddTransient<ICityRepository, CityRepository>();
            //services.AddTransient<IRouteRepository, RouteRepository>();
            //services.AddTransient<ISeatManagementRepository, SeatManagementRepository>();
            //services.AddTransient<ITransectionRepository, TransectionRepository>();
            //services.AddTransient<IUserHotelBookRepository, UserHotelBookRepository>();
            //services.AddTransient<IUserHotelBookRepository, UserHotelBookRepository>();
            //services.AddTransient<IUserRepository, UserRepository>();
            services.AddMvc();
                    }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, AirlineContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();


            #pragma warning disable CS0612 // Type or member is obsolete
            app.UseApplicationInsightsRequestTelemetry();
            #pragma warning restore CS0612 // Type or member is obsolete

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            #pragma warning disable CS0612 // Type or member is obsolete
            app.UseApplicationInsightsExceptionTelemetry();
            #pragma warning restore CS0612 // Type or member is obsolete
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            DbInitializer.Initialize(context);
        }
    }
}
