using CleanArchitectureDDDTutorial.Application.Common.Interfaces.Services;

namespace CleanArchitectureDDDTutorial.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
