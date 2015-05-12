using System;

namespace Aspnet5MessageLibrary
{
    public class MessageService : IMessageService
    {
        private readonly DateTime currentDate;

        public MessageService()
        {
            currentDate = DateTime.Now;
        }

        public string GetDatedMessage()
        {
            return $"Current time is {currentDate}";
        }

        public string GetHelloWorldMessage()
        {
            return "Hello World!";
        }

        public string GetWelcomeMessage()
        {
            return "Welcome to ASP.NET 5";
        }
    }
}
