using Microsoft.AspNetCore.Mvc;

namespace Practica4Routing.Areas.Special.Controllers
{
    [Area("Special")]
    public class FriendsController : Controller
    {
        // Esta acción se usará cuando la URL sea /Friends/View/{name}
        public IActionResult View(string name)
        {
            return Content($"FriendsController NUEVO (Area Special) - View('{name}')");
        }
    }
}
