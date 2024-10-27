using Microsoft.AspNetCore.Mvc;

namespace creWin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
