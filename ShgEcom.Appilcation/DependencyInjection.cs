using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShgEcom.Application.Common.Behaviours;
using System.Reflection;

namespace ShgEcom.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddMemoryCache();
            services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
