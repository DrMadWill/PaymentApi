using BankIntegration.Interfaces;
using BankIntegration.Models;
using BankIntegration.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankIntegration;

public static  class ServiceRegistration
{
    public static IServiceCollection  AddPayriffService(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null || configuration == null)
            throw new ArgumentNullException("services and configuration");

        var config = configuration.GetSection("Payriff").Get<PayriffConfiguration>();
        
        services.AddSingleton(config);
        services.AddScoped<IPayriffService, PayriffService>();

        return services;

    } 
}