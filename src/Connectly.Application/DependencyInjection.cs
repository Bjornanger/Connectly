using Connectly.Application.FactoryForServices;
using Connectly.Application.Interfaces.ServiceInterfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Connectly.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);
        
        services.AddScoped<IServiceFactory, ServiceFactory>();

        return services;
    }

    
}