using Microsoft.Extensions.DependencyInjection;

namespace TruckAssist.Api.Extensions
{
    public static class CorsPolicyExtension
    {
        public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
        
          =>  services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });
           
        
    }
}
