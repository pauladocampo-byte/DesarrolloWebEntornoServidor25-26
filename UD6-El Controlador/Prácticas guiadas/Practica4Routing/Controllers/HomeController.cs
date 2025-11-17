using Microsoft.AspNetCore.Mvc;

namespace Practica4Routing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
