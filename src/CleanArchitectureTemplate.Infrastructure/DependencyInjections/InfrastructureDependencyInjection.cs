using CleanArchitectureTemplate.Application.Abstractions.Events;
using CleanArchitectureTemplate.Application.Abstractions.Persistence;
using CleanArchitectureTemplate.BuildingBlocks.Abstractions;
using CleanArchitectureTemplate.Infrastructure.Events;
using CleanArchitectureTemplate.Infrastructure.Persistence.InMemory;
using CleanArchitectureTemplate.Infrastructure.Time;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IToDoListRepository, InMemoryToDoListRepository>();
        services.AddSingleton<IUnitOfWork, InMemoryUnitOfWork>();

        services.AddSingleton<IDateTimeProvider, SystemDateTimeProvider>();

        services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

        return services;
    }
}
