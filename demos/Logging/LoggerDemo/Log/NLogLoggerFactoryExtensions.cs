using System;
using System.IO;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Logging;
using NLog;

namespace LoggerDemo.Log
{
    public static class NLogLoggerFactoryExtensions
    {
        public static ILoggerFactory AddNLog(this ILoggerFactory factory, IHostingEnvironment env)
        {
            var path = Path.Combine(env.WebRootPath, "NLog.config");
            var xmlConfig = new NLog.Config.XmlLoggingConfiguration(path);
            var logFactory = new LogFactory(xmlConfig);

            return AddNLog(factory, logFactory);
        }

        public static ILoggerFactory AddNLog(this ILoggerFactory factory, LogFactory logFactory)
        {
            factory.AddProvider(new NLogLoggerProvider(logFactory));
            return factory;
        }
    }
}