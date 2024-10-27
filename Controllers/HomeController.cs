using Microsoft.AspNetCore.Mvc;

namespace creWin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
