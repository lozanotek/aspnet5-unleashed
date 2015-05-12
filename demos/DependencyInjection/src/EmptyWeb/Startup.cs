using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

using Aspnet5MessageLibrary;

namespace EmptyWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IMessageService, MessageService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var service = context.ApplicationServices.GetService<IMessageService>();
                await context.Response.WriteAsync(service.GetWelcomeMessage());
            });
        }
    }
}
