using blog_service.External.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace blog_service.External
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterPersistance(this IServiceCollection services, string dbConnectionString)
        {
            services.AddDbContext<BlogDbContext>(
                options => options.UseMySql(
                    dbConnectionString,
                    ServerVersion.AutoDetect(dbConnectionString)
                )
            );
            return services;
        }
    }
}
