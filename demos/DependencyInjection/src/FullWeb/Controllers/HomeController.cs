using Microsoft.AspNet.Mvc;
using Aspnet5MessageLibrary;

namespace FullWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMessageService messageService;

        public HomeController(IMessageService service)
        {
            messageService = service;
        }

        public IActionResult Index()
        {
            var message = messageService.GetWelcomeMessage();
            ViewBag.WelcomeMessage = message;

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
