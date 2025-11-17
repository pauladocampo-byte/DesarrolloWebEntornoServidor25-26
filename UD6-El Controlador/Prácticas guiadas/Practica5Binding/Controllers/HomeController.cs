using Microsoft.AspNetCore.Mvc;

namespace Practica5Binding.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
