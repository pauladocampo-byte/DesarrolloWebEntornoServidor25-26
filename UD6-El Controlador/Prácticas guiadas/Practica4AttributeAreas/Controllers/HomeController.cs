using Microsoft.AspNetCore.Mvc;

namespace Practica4AttributeAreas.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
