using Microsoft.Framework.Logging;
using NLog;

namespace NLogLib
{
    public class NLogLoggerProvider : ILoggerProvider
    {
        private readonly LogFactory _logFactory;

        public NLogLoggerProvider(LogFactory logFactory)
        {
            _logFactory = logFactory;
        }

        public Microsoft.Framework.Logging.ILogger CreateLogger(string name)
        {
            return new NLogLogger(_logFactory.GetLogger(name));
        }
    }
}