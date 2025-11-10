using Microsoft.EntityFrameworkCore;
using MontecasteloAuthDemo.Models;
using MontecasteloAuthDemo.Services;

namespace MontecasteloAuthDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(e =>
            {
                e.ToTable("Usuarios");
                e.HasIndex(u => u.NombreUsuario).IsUnique();
                e.Property(p => p.NombreUsuario).HasMaxLength(40);
                e.Property(p => p.PasswordHash).HasMaxLength(128);
                e.Property(p => p.Salt).HasMaxLength(64);
                e.Property(p => p.Rol).HasMaxLength(20);
            });

            // Seed admin/admin123 con salt fijo
            const string adminSalt = "t7mY0q5m1v7rN6c1Rz9sYw=="; // 16 bytes Base64 de ejemplo
            string adminHash = PasswordHasher.HashPassword("admin123", adminSalt);

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = 1,
                NombreUsuario = "admin",
                Salt = adminSalt,
                PasswordHash = adminHash,
                Rol = Roles.Admin
            });
        }
    }
}
