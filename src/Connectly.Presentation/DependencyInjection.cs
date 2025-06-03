using Connectly.Application;
using Connectly.Infrastructure;
using Connectly.Infrastructure.ExternalServices.Email;
using Connectly.Presentation.FrontendService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connectly.Presentation;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration config)
    {
        services.Configure<MailAppSettings>(config.GetSection("MailAppSettings"));

        services.AddApplication()
            .AddInfrastructure(config);

        

        services.AddScoped<MultiService>();
        return services;
    }
}