using Microsoft.EntityFrameworkCore;

namespace BlogSimple.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }
        public DbSet<Post> Posts { get; set; }
    }
}
