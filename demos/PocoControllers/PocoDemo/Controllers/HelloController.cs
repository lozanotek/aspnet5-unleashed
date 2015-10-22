using Aspnet5MessageLibrary;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ModelBinding;

namespace PocoDemo.Controllers
{
    public class HelloController
    {
        public IMessageService MessageService { get; set; }

        public HelloController(IMessageService messageService)
        {
            MessageService = messageService;
        }

        public IActionResult Index()
        {
            var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = MessageService.GetWelcomeMessage()
            };

            return new ViewResult
            {
                ViewName = "Index",
                ViewData = viewData
            };
        }

        public dynamic Data()
        {
            return new
            {
                Prop1 = "Hello",
                Prop2 = 12345
            };
        }
    }
}
