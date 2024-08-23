using DrMadWill.EventBus.Base;
using DrMadWill.EventBus.Base.Abstractions;
using DrMadWill.EventBus.RabbitMQ;
using DrMW.Cqrs.Repository.Abstractions.Cqrs;
using DrMW.Cqrs.Repository.Abstractions.SystemRepos;
using DrMW.Cqrs.Repository.Concretes.Cqrs;
using DrMW.Cqrs.Repository.Concretes.SystemRepos;
using DrMW.Cqrs.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace DrMW.Cqrs.Repository;

public static class ServiceRegistration
{
    public static void AddRepositories(this IServiceCollection services,IConfiguration configuration)
    {
        if (services == null) throw new AggregateException("service is null");

        services.AddDbContext<AppDb>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        
        services.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
        services.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));
        
        services.AddScoped<ISelectRepositories, SelectRepositories>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        
        services.AddSingleton<IEventBus>(sp =>
        {
            EventBusConfig config = new()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "Payment.Service",
                EventBusType = EventBusType.RabbitMQ
            };
            
            return new EventBusRabbitMq(config, sp,new ConnectionFactory
            {
                Uri = new Uri(configuration["RabbitMq"])
            });
        });
        
        //services.EventBusHandlers();
    }

    // private static IServiceCollection EventBusHandlers(this IServiceCollection services)
    // {
    //     //services.AddTransient<OrderChangingHandler>();
    //     return services;
    // }
    //
    // public static void UsingSubScribes(this IEventBus eventBus)
    // {
    //     //eventBus.Subscribe<OrderChangingIntegrationEvent, OrderChangingHandler>();
    // }
}