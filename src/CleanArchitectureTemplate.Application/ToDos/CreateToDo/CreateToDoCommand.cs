using CleanArchitectureTemplate.Application.Abstractions.Events;
using CleanArchitectureTemplate.Application.Abstractions.Persistence;
using CleanArchitectureTemplate.BuildingBlocks.Abstractions;
using CleanArchitectureTemplate.BuildingBlocks.Results;
using CleanArchitectureTemplate.Domain.ToDos.Entities;

namespace CleanArchitectureTemplate.Application.ToDos.CreateToDo;
public sealed record CreateToDoCommand(string Title);

public sealed class CreateToDoHandler
{
    private readonly IToDoListRepository _repo;
    private readonly IUnitOfWork _uow;
    private readonly IDateTimeProvider _clock;
    private readonly IDomainEventDispatcher _dispatcher;

    public CreateToDoHandler(IToDoListRepository repo, IUnitOfWork uow, IDateTimeProvider clock, IDomainEventDispatcher dispatcher)
    {
        _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        _clock = clock ?? throw new ArgumentNullException(nameof(clock));
        _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));

    }

    public async Task<Result<CreateToDoDto>> HandleAsync(CreateToDoCommand command, CancellationToken ct)
    {
        ArgumentNullException.ThrowIfNull(command);

        var titleResult = ToDoTitle.Create(command.Title);

        if (titleResult.IsFailure)
            return Result.Failure<CreateToDoDto>(titleResult.Error);

        var list = await _repo.GetDefaultAsync(ct).ConfigureAwait(false) ?? new ToDoList();

        var add = list.AddItem(titleResult.Value, _clock.UtcNow);
        if (add.IsFailure)
            return Result.Failure<CreateToDoDto>(add.Error);

        _repo.Upsert(list);
        await _uow.SaveChangesAsync(ct).ConfigureAwait(false);

        await _dispatcher.DispatchAsync(list.DomainEvents, ct).ConfigureAwait(false);
        list.ClearDomainEvents();

        var item = add.Value;
        return Result.Success(new CreateToDoDto(list.Id, item.Id, item.Title.Value, item.IsDone));

    }
}
