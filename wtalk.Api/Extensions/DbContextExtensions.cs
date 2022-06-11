using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wtalk.Infrastracture.Data.Context;

namespace TruckAssist.Api.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration config)
        {
           
            services.AddDbContext<DbReadContext>(x => x.UseMySql(config["ConnectionStrings:ReadConnection"], ServerVersion.AutoDetect(config["ConnectionStrings:ReadConnection"])));
            services.AddDbContext<DbWriteContext>(x => x.UseMySql(config["ConnectionStrings:WriteConnection"], ServerVersion.AutoDetect(config["ConnectionStrings:WriteConnection"])));
            return services;
        }
    }
}
