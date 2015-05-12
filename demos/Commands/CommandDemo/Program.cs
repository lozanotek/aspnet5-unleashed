using System;
using Microsoft.Framework.Runtime;

namespace CommandDemo
{
    public class Program
    {
        public IApplicationEnvironment ApplicationEnvironment { get; set; }

        public Program(IApplicationEnvironment applicationEnvironment)
        {
            ApplicationEnvironment = applicationEnvironment;
        }

        public void Main(string[] args)
        {
            Console.WriteLine("Command Demo");

            var framework = ApplicationEnvironment.RuntimeFramework;
            var message = $"Framework: {framework.FullName}\r\nVersion:{framework.Version}";

            Console.WriteLine(message);
            Console.In.ReadLine();
        }
    }
}
