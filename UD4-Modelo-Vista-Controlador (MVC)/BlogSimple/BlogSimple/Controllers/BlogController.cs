using BlogSimple.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSimple.Controllers
{
    public class BlogController : Controller
    {
        private readonly PostManager _postManager;

        public BlogController(PostManager postManager)
        {
            _postManager = postManager;
        }
        public IActionResult Index()
        {
            var posts = _postManager.GetLastestPosts(10);
            return View(posts);
        }
    }
}
