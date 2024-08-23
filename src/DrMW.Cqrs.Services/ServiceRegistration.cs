using BankIntegration;
using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Service.Mappers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrMW.Cqrs.Service;

public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection services,IConfiguration configuration)
    {
        if (services == null) throw new AggregateException("service is null");
        
        services.AddAutoMapper(typeof(DrMWMapper));
        
        services.AddMediatR((config =>
        {
            config.RegisterServicesFromAssemblies(typeof(ServiceRegistration).Assembly, typeof(BaseEntity<>).Assembly);
        }));
        services.AddPayriffService(configuration);
    } 
}