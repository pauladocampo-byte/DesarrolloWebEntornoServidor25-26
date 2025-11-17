using Microsoft.AspNetCore.Mvc;

namespace Practica4AttributeAreas.Controllers
{
    [Route("Products")]
    public class ProductsController : Controller
    {
        // GET /, /Products, /Products/All
        [HttpGet("/")]
        [HttpGet("")]
        [HttpGet("All")]
        public IActionResult Index()
        {
            return Content("ProductsController.Index() - listado de todos los productos");
        }

        // GET /Products/Sony-Vaio
        [HttpGet("{id}")]
        public IActionResult View(string id)
        {
            return Content($"ProductsController.View('{id}')");
        }

        // GET /Products/Category/Ultrabooks
        [HttpGet("Category/{category}")]
        public IActionResult ByCategory(string category)
        {
            return Content($"ProductsController.ByCategory('{category}')");
        }
    }
}
