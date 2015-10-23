using Microsoft.AspNet.Builder;

namespace LoggerMiddleware
{
    // Source: https://docs.asp.net/en/latest/fundamentals/middleware.html
    public static class LoggerMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogger>();
        }
    }
}
