using CleanArchitectureTemplate.BuildingBlocks.Domain;

namespace CleanArchitectureTemplate.Domain.ToDos.Events;
public sealed record ToDoItemAddedDomainEvent(
    DateTime EventTime,
    Guid ListId,
    Guid ItemId,
    string Title
) : IDomainEvent;
