using CineMontecasteloMvc.Models;
using Microsoft.EntityFrameworkCore;
using CineMontecasteloMvc.ViewModels;

namespace CineMontecasteloMvc.Data
{
    public class CineContext : DbContext
    {
        public CineContext(DbContextOptions<CineContext> options) : base(options)
        {
        }
        public DbSet<Pelicula> Peliculas { get; set; } 
        public DbSet<Sala> Salas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Precio con precisión/escala explícita para evitar warnings y truncado
            modelBuilder.Entity<Pelicula>()
                .Property(p => p.Precio)
                .HasPrecision(6, 2);
            // Configurar relación Sala -> Pelicula como opcional y borrar en cascada a SetNull
            modelBuilder.Entity<Sala>()
                .HasOne(s => s.Pelicula)
                .WithMany(p => p.Salas)
                .HasForeignKey(s => s.PeliculaId)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed de usuario admin (hash estable)
            // Calculado fuera de OnModelCreating para no cambiar entre ejecuciones
            const string adminHash = "100000.hiZiCsDch3ZBoZOrt+jH2w==.9J8zFXeNof73L5Qf9ya2E1XH+mXOM9dsowCyncZKwVI=";
            modelBuilder.Entity<Usuario>().HasData(
               new Usuario
               {
                   Id = 1,
                   NombreUsuario = "admin",
                   PasswordHash = adminHash
               });

            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula
                {
                    Id = 1,
                    Titulo = "Inside Out 2",
                    Descripcion = "Las emociones vuelven con nuevas aventuras.",
                    Genero = "Animación",
                    Anio = 2024,
                    Duracion = 110,
                    Precio = 9.50m

                },
                  new Pelicula
                  {
                      Id = 2,
                      Titulo = "Dune:Parte Dos",
                      Descripcion = "Paul Atreides y los Fremen en Arrakis.",
                      Genero = "Ciencia ficción",
                      Anio = 2024,
                      Duracion = 165,
                      Precio = 9.00m

                  }

             );

            modelBuilder.Entity<Sala>().HasData(
                new Sala
                {
                    Id = 1,
                    Nombre = "Sala 1",
                    Aforo = 150,
                    PeliculaId = 1
                },
                new Sala
                {
                    Id = 2,
                    Nombre = "Sala 2",
                    Aforo = 100,
                    PeliculaId = 2
                },
                new Sala
                {
                    Id = 3,
                    Nombre = "Sala 3",
                    Aforo = 80,
                    PeliculaId = null
                }
            );

        }
        public DbSet<CineMontecasteloMvc.ViewModels.PeliculaEditViewModel> PeliculaEditViewModel { get; set; } = default!;
    }
}
