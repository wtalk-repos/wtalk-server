using Microsoft.Extensions.DependencyInjection;
using Wtalk.Core.Interfaces;
using Wtalk.Core.Interfaces.Repositories;
using Wtalk.Core.Interfaces.Services;
using Wtalk.Infrastracture.Data;
using Wtalk.Infrastracture.Repository;
using Wtalk.Infrastracture.Service;
using Wtalk.Infrastructure.Data.Repository;

namespace Wtalk.Api.Extensions
{
    public  static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddScoped(typeof(IReadGenericRepository<>), (typeof(ReadGenericRepository<>)));
            services.AddScoped<IDataProtectionService, DataProtectionService>();
            return services;
        }
        }
}
