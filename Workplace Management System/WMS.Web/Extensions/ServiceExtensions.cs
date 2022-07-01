using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using WMS.Repository.Contexts;
using WMS.Repository.DataShaping.Implementations;
using WMS.Repository.DataShaping.Interfaces;
using WMS.Repository.Repositories.Implementations;
using WMS.Repository.Repositories.Interfaces;
using WMS.Service.Dtos.Floor;
using WMS.Service.Implementations;
using WMS.Service.Interfaces;
using WMS.Web.ActionFilters;

namespace WMS.Web.Extensions
{
    public static class ServiceExtensions
    {
        // Use this to configure Cross-Origin Resource Sharing (CORS)
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        // Use this to configure IIS
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        // Register LoggerManager
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        // Register DbContexts
        public static void ConfigureSqlContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AuthConnectionString")));
            services.AddDbContext<CoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CoreConnectionString")));
        }

        // Register RepositoryManager 
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        // Register services
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISitesService, SitesService>();
            services.AddScoped<IFloorsService, FloorsService>();

            services.AddScoped<ValidationFilterAttribute>();

            services.AddScoped<IDataShaper<FloorDto>, DataShaper<FloorDto>>();
        }

        // configure rate limit
        public static void ConfigureRateLimitingOptions(this IServiceCollection services) 
        { 
            var rateLimitRules = new List<RateLimitRule> 
            { 
                new RateLimitRule 
                { 
                    Endpoint = "*", 
                    Limit = 1, 
                    Period = "1s" 
                } 
            }; 
            
            services.Configure<IpRateLimitOptions>(opt => 
            { 
                opt.GeneralRules = rateLimitRules; 
            }); 
            
            services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>(); 
            services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>(); 
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>();
        }
    }
}
