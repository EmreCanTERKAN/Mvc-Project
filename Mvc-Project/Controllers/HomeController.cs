using Microsoft.AspNetCore.Mvc;

namespace Mvc_Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
