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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    PostId = 1,
                    Title = "Bienvenidos al Blog",
                    Code = "Esta es la primera entrada: practicando MVC y Razor.",
                    Text = "This is the first post on my blog. Stay tuned for more content!",
                    Date = new DateTime(2024, 10, 1),
                    Author = "Paula Docampo"
                }, new Post
                {
                    PostId = 2,
                    Title = "Segunda Entrada",
                    Code = "Explorando más sobre ASP.NET Core.",
                    Text = "In this post, we will explore more features of ASP.NET Core.",
                    Date = new DateTime(2024, 10, 1),
                    Author = "Paula Docampo"
                }
            );
        }
    }
}
