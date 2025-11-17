using Microsoft.AspNetCore.Mvc;

namespace Practica4AttributeAreas.Areas.Special.Controllers
{
    [Area("Special")]
    [Route("Friends/View")]
    public class FriendsController : Controller
    {
        // GET /Friends/View/John
        [HttpGet("{name}")]
        public IActionResult View(string name)
        {
            return Content($"FriendsController NUEVO (Area Special) - View('{name}')");
        }
    }
}
