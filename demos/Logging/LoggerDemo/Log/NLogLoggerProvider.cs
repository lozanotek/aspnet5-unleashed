using System;
using Microsoft.Framework.Logging;
using NLog;
using LogLevel = Microsoft.Framework.Logging.LogLevel;

namespace LoggerDemo.Log
{
    public class NLogLoggerProvider : ILoggerProvider
    {
        private readonly LogFactory _logFactory;

        public NLogLoggerProvider(LogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        public ILogger CreateLogger(string name)
        {
            return new Logger(_logFactory.GetLogger(name));
        }

        private class Logger : ILogger
        {
            private readonly NLog.Logger _logger;

            public Logger(NLog.Logger logger)
            {
                _logger = logger;
            }

            public void Log(
                LogLevel logLevel,
                int eventId,
                object state,
                Exception exception,
                Func<object, Exception, string> formatter)
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

            public bool IsEnabled(LogLevel logLevel)
            {
                return _logger.IsEnabled(GetLogLevel(logLevel));
            }

            public IDisposable BeginScope(object state)
            {
                return NestedDiagnosticsContext.Push(state.ToString());
            }

            private NLog.LogLevel GetLogLevel(LogLevel logLevel)
            {
                switch (logLevel)
                {
                    case LogLevel.Verbose: return global::NLog.LogLevel.Debug;
                    case LogLevel.Information: return global::NLog.LogLevel.Info;
                    case LogLevel.Warning: return global::NLog.LogLevel.Warn;
                    case LogLevel.Error: return global::NLog.LogLevel.Error;
                    case LogLevel.Critical: return global::NLog.LogLevel.Fatal;
                }
                return global::NLog.LogLevel.Debug;
            }
        }
    }
}