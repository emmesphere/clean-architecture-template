namespace CleanArchitectureTemplate.BuildingBlocks.Abstractions;
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
