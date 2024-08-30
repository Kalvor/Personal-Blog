using blog_service.Application.Abstraction;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace blog_service.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(ServiceRegistration)));
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblyContaining(typeof(ServiceRegistration));
                config.AddRequestPreProcessor(typeof(ValidationPreProcessor<>));
                config.AddBehavior(typeof(LoggingBehavior<,>));
            });
            
            return services;
        }
    }
}
