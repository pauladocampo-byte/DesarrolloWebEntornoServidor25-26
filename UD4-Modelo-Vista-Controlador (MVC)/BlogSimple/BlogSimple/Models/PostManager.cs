namespace BlogSimple.Models
{
    public class PostManager
    {
        private readonly BlogContext _context;

        public PostManager(BlogContext context)
        {
            _context = context;
        }

        public List<Post> GetLastestPosts(int max)
        {
            //var posts = from post in _context.Posts
            //            orderby post.Date descending
            //            select post;
            //return posts.Take(max).ToList();

            return _context.Posts
                .OrderByDescending(p => p.Date).Take(max).ToList();
        }

        public Post? GetPost(int id)
        {
            return _context.Posts.Find(id);
        }

        public List<Post> GetPostByDate(int year, int month)
        {
            return _context.Posts
                .Where(p => p.Date.Year == year && p.Date.Month == month).ToList();
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void DeletePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                _context.SaveChanges();
            }
        }
        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}
