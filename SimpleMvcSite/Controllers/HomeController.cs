using Microsoft.AspNetCore.Mvc;

namespace SimpleMvcSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Recipes()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
