using Microsoft.AspNetCore.Mvc;

namespace NineStart.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
