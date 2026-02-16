using CleanArchitectureTemplate.Domain.ToDos.Entities;

namespace CleanArchitectureTemplate.Application.Abstractions.Persistence;

public interface IToDoListRepository
{
    Task<ToDoList?> GetDefaultAsync(CancellationToken ct);
    void Upsert(ToDoList list);
}
