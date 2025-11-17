using Microsoft.AspNetCore.Mvc;

namespace Practica4Routing.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult Index()
        {
            return Content("FriendsController ORIGINAL - Index()");
        }

        public IActionResult View(string name)
        {
            return Content($"FriendsController ORIGINAL - View('{name}')");
        }

        public IActionResult Edit(int id)
        {
            return Content($"FriendsController ORIGINAL - Edit({id})");
        }
    }
}
