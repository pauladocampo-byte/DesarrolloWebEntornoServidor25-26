using Forum.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Browser(string forumName)
        {
            var msgs = MensajeRepository.GetByForum(forumName);
            return View("Browse", msgs);
        }
    }
}
