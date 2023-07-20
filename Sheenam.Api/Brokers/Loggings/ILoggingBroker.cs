using System;

namespace Sheenam.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LoggingError(Exception exception);
        void LoggingCritical(Exception exception);
    }
}
