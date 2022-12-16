using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using SinisterApi.Infra.Logger.Interfaces;
using SinisterApi.Infra.Logger.Models;
using System.Runtime.CompilerServices;

namespace SinisterApi.Infra.Logger.Services
{
    internal class LogWriter : ILogWriter
    {

        private readonly string _appName;
        private ILogger _logger;

        private bool _disposedValue;
        private Guid _correlationId;

        public LogWriter(
            ILogger logger,
            IConfiguration configuration) =>
            (_logger, _appName) = (logger, configuration["AppName"]);


        public void SetCorrelationId(Guid correlationId)
        {
            _correlationId = correlationId;
        }

        public void Info(string message, object data = null, Exception ex = null, [CallerMemberName] string source = "")
        {
            Log(message, data, ex, source, LogEventLevel.Information, _logger.Information);
        }
        public void Error(string message, object data = null, Exception ex = null, [CallerMemberName] string source = "")
        {
            Log(message, data, ex, source, LogEventLevel.Error, _logger.Error);
        }

        public void Fatal(string message, object data = null, Exception ex = null, [CallerMemberName] string source = "")
        {
            Log(message, data, ex, source, LogEventLevel.Fatal, _logger.Fatal);
        }

        public void Warn(string message, object data = null, Exception ex = null, [CallerMemberName] string source = "")
        {
            Log(message, data, ex, source, LogEventLevel.Warning, _logger.Warning);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (!_disposedValue)
            {

                if (disposing)
                {
                    _logger = null;
                }

                _disposedValue = true;
            }
        }

        private void Log(
            string message,
            object data,
            Exception ex,
            string source,
            LogEventLevel level,
            Action<string, LogMessage> logger)
        {

            var correlationId = _correlationId == Guid.Empty ? Guid.NewGuid() : _correlationId;
            var logMessage = new LogMessage
            {
                Application = _appName,
                Data = data,
                Level = level.ToString(),
                Message = message,
                Method = source,
                Timestamp = DateTime.Now,
                CorrelationId = correlationId.ToString(),
            };

            if (ex != null)
            {
                logMessage.StackTrace = $"{ex.Message} {ex.StackTrace}";
            }

            logger.Invoke("{@LogMessage}", logMessage);
        }
    }
}
