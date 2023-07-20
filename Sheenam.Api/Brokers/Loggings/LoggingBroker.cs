using Microsoft.Extensions.Logging;
using System;

namespace Sheenam.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> logger)=>
            this.logger = logger;

        public void LoggingError(Exception exception) =>
            this.logger.LogError(exception, exception.Message);

        public void LoggingCritical(Exception exception) =>
            this.logger.LogCritical(exception, exception.Message);
    }
}
