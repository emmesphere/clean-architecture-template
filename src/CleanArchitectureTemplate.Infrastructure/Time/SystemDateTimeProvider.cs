
using CleanArchitectureTemplate.BuildingBlocks.Abstractions;

namespace CleanArchitectureTemplate.Infrastructure.Time;
public class SystemDateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
