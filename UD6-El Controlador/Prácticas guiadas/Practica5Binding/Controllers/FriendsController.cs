using Microsoft.AspNetCore.Mvc;
using Practica5Binding.Models;
using System.Linq;

namespace Practica5Binding.Controllers
{
    public class FriendsController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            var newFriend = new Friend
            {
                Address = new Address()
            };

            return View(newFriend);
        }

        [HttpPost]
        public IActionResult Create(Friend friend)
        {
            if (!ModelState.IsValid)
            {
                var errorFields = string.Join(", ",
                    ModelState.Keys.Where(key => !ModelState.IsValidField(key)));

                ViewBag.ErrorFields = errorFields;
                return View(friend);
            }

            return Content("OK");
        }
    }
}
