using ShgEcom.Application.Common.Interfaces.Services;

namespace ShgEcom.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
