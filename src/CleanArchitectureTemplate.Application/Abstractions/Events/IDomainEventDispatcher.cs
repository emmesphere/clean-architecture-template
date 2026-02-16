using CleanArchitectureTemplate.BuildingBlocks.Domain;

namespace CleanArchitectureTemplate.Application.Abstractions.Events;
public  interface IDomainEventDispatcher
{
    Task DispatchAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken);
}
