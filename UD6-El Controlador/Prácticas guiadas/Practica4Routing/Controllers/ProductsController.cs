using Microsoft.AspNetCore.Mvc;

namespace Practica4Routing.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return Content("ProductsController.Index() - listado de todos los productos");
        }

        public IActionResult View(string id)
        {
            return Content($"ProductsController.View('{id}')");
        }

        public IActionResult ByCategory(string category)
        {
            return Content($"ProductsController.ByCategory('{category}')");
        }
    }
}
