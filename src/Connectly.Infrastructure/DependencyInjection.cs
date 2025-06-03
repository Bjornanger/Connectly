using Connectly.Application.Interfaces;
using Connectly.Application.Interfaces.RepositoryInterfaces;
using Connectly.Application.Interfaces.ServiceInterfaces;
using Connectly.Domain.Entities;
using Connectly.Infrastructure.Data;
using Connectly.Infrastructure.ExternalServices;
using Connectly.Infrastructure.ExternalServices.Excel;
using Connectly.Infrastructure.ExternalServices.Serilog;
using Connectly.Infrastructure.FactoryForExternalServices;
using Connectly.Infrastructure.FactoryForRepositories;
using Connectly.Infrastructure.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connectly.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {

        var connectionString = config.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });

        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();


       



        services.AddScoped<IRepositoryFactory, RepositoryFactory>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // External Service Factory
        services.AddScoped<IExternalServiceFactory, ExternalServiceFactory>();


        // External services

        services.AddSingleton<ISerilogLogger, SerilogLogger>();
        services.AddScoped<IWorkBook, WorkBook>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IEmailSender, EmailService>();
        services.AddScoped<IPasswordGeneratorService, PasswordGeneratorService>();

        return services;
    }


}