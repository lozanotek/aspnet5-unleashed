using Microsoft.AspNet.Mvc;

namespace TagHelperDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
