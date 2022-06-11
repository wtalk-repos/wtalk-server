using Microsoft.Extensions.DependencyInjection;
using Wtalk.Core.Interfaces;
using Wtalk.Core.Interfaces.Repositories;
using Wtalk.Infrastracture.Data;
using Wtalk.Infrastracture.Repository;
using Wtalk.Infrastracture.Service;

namespace Wtalk.Api.Extensions
{
    public  static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            //services.AddScoped(typeof(IReadGenericRepository<>), (typeof(ReadGenericRepository<>)));

            return services;
        }
        }
}
