using System;
using Microsoft.Framework.Logging;
using NLog;

namespace NLogLib
{
    internal class NLogLogger : Microsoft.Framework.Logging.ILogger
    {
        private readonly Logger _logger;

        public NLogLogger(Logger logger)
        {
            _logger = logger;
        }

        public void Log(Microsoft.Framework.Logging.LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
        {
            var nLogLogLevel = GetLogLevel(logLevel);
            var message = string.Empty;
            if (formatter != null)
            {
                message = formatter(state, exception);
            }
            else
            {
                message = LogFormatter.Formatter(state, exception);
            }
            if (!string.IsNullOrEmpty(message))
            {
                var eventInfo = LogEventInfo.Create(nLogLogLevel, _logger.Name, message, exception);
                eventInfo.Properties["EventId"] = eventId;
                _logger.Log(eventInfo);
            }
        }

        public bool IsEnabled(Microsoft.Framework.Logging.LogLevel logLevel)
        {
            return _logger.IsEnabled(GetLogLevel(logLevel));
        }

        public IDisposable BeginScopeImpl(object state)
        {
            return NestedDiagnosticsContext.Push(state.ToString());
        }

        private NLog.LogLevel GetLogLevel(Microsoft.Framework.Logging.LogLevel logLevel)
        {
            switch (logLevel)
            {
                case Microsoft.Framework.Logging.LogLevel.Verbose: return NLog.LogLevel.Debug;
                case Microsoft.Framework.Logging.LogLevel.Information: return NLog.LogLevel.Info;
                case Microsoft.Framework.Logging.LogLevel.Warning: return NLog.LogLevel.Warn;
                case Microsoft.Framework.Logging.LogLevel.Error: return NLog.LogLevel.Error;
                case Microsoft.Framework.Logging.LogLevel.Critical: return NLog.LogLevel.Fatal;
            }
            return NLog.LogLevel.Debug;
        }
    }
}