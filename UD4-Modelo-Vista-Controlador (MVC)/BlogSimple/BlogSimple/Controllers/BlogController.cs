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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _postManager.GetPost(id);
            if (post == null)
                return NotFound();
            else
                return View(post);
        }

        public IActionResult Edit(int id, Post post)
        {
            if( id != post.PostId)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            _postManager.UpdatePost(post);
            TempData["Msg"] = "Post modificado correctamente.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Post { Date = DateTime.Today });
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            _postManager.AddPost(post);

            TempData["Msg"] = "Post creado correctamente.";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var post = _postManager.GetPost(id);
            if (post == null)
               return NotFound();
            else
                return View(post);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _postManager.DeletePost(id);
            TempData["Msg"] = "Post eliminado correctamente.";
            return RedirectToAction("Index");
        }
    }
}
