using System.Threading.Tasks;

using Microsoft.AspNet.Builder;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Http;

namespace LoggerMiddleware
{
    // Source: https://docs.asp.net/en/latest/fundamentals/middleware.html
    public class RequestLogger
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLogger(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLogger>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation($"Request: {context.Request.Path}");
            context.Response.OnResponseCompleted(obj =>
            {
                var l = obj as ILogger;
                l.LogInformation("Response Completed");
            }, _logger);

            await _next.Invoke(context);
            _logger.LogInformation("Completed Logging Request");
        }
    }
}
