using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Logging;

namespace LoggerDemo.Controllers
{
    public class HomeController : Controller
    {
        public ILogger Logger { get; set; }

        public HomeController(ILoggerFactory logFactory)
        {
            Logger = logFactory.CreateLogger<HomeController>();
        }

        public IActionResult Index()
        {
            Logger.LogInformation("Index action");
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
