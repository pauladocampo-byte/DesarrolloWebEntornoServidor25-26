using Microsoft.AspNetCore.Mvc;

namespace Practica4AttributeAreas.Controllers
{
    // Controlador Friends "original"
    [Route("Friends")]
    public class FriendsController : Controller
    {
        // GET /Friends  o /Friends/Index
        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return Content("FriendsController ORIGINAL - Index()");
        }

        // GET /Friends/Edit/23  (solo acepta enteros >=1)
        [HttpGet("Edit/{id:int:min(1)}")]
        public IActionResult Edit(int id)
        {
            return Content($"FriendsController ORIGINAL - Edit({id})");
        }

        // GET /Friends/ViewOriginal/John
        [HttpGet("ViewOriginal/{name}")]
        public IActionResult ViewOriginal(string name)
        {
            return Content($"FriendsController ORIGINAL - View('{name}')");
        }
    }
}
