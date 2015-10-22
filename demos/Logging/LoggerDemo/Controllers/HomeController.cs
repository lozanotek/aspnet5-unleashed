using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;

namespace LoggerDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILoggerFactory logFactory)
        {
            _logger = logFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index action");
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            _logger.LogInformation("About action");

            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            _logger.LogInformation("Contact action");

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
