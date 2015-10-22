using System;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;

namespace CommandDemo
{
    public class Program
    {
        private readonly IApplicationEnvironment _appEnvironment;
        public IConfiguration Configuration { get; set; }

        public Program(IApplicationEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public void Main(string[] args)
        {
            var builder = new ConfigurationBuilder(_appEnvironment.ApplicationBasePath)
               .AddCommandLine(args);

            Configuration = builder.Build();
            Console.WriteLine("[Command Demo]");

            var framework = _appEnvironment.RuntimeFramework;
            var message = $"\tFramework: {framework.FullName}\r\n\tVersion:{framework.Version}";
            Console.WriteLine(message);

            var echoText = Configuration.Get("echo");
            if (!string.IsNullOrWhiteSpace(echoText))
            {
                Console.WriteLine($"\t[echo]: {echoText}", echoText);
            }

            Console.Write("Press any key to continue...");
            // Not available in dnx core 5
            //Console.ReadKey(true);
        }
    }
}
