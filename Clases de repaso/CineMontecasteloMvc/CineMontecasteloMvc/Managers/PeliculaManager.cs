using CineMontecasteloMvc.Data;
using CineMontecasteloMvc.Managers.Interfaces;
using CineMontecasteloMvc.Models;
using CineMontecasteloMvc.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace CineMontecasteloMvc.Managers
{
    public class PeliculaManager : IPeliculaManager
    {
        private readonly CineContext _context;

        public PeliculaManager(CineContext context)
        {
            _context = context;
        }   

        public void Create(Pelicula pelicula, IFormFile? foto)
        {
            if(foto != null && foto.Length>0 )
            {
                using var ms = new MemoryStream();
                foto.CopyTo(ms);
                pelicula.Foto = ms.ToArray();
                pelicula.FotoMimeType = foto.ContentType;
            }
            _context.Peliculas.Add(pelicula);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pelicula = _context.Peliculas.Find(id);
            if(pelicula != null)
            {
                _context.Peliculas.Remove(pelicula);
                _context.SaveChanges();
            }
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.OrderBy(p=>p.Titulo).ToList();

        }

        public List<Sala> GetAllSalas()
        {
            return _context.Salas.OrderBy(s => s.Nombre).ToList();
        }

        public Pelicula? GetById(int id)
        {
            return _context.Peliculas.Find(id);
        }

        public List<Pelicula> GetCartelera()
        {
            return _context.Peliculas
                .Include(p=> p.Salas)
                .OrderBy(p => p.Titulo).ToList();
        }

        public (byte[]? ImageData, string? MimeType) GetImagen(int id)
        {
           var pelicula = _context.Peliculas.Find(id);
            if ( pelicula == null || pelicula.Foto == null || string.IsNullOrEmpty(pelicula.FotoMimeType))
            {
                return (null, null);
            }
            return (pelicula.Foto, pelicula.FotoMimeType);
        }

        public Pelicula GetWithSalas(int id)
        {
            return _context.Peliculas.Include(p => p.Salas)
                                     .FirstOrDefault(p => p.Id == id)!;

        }

        public void Update(PeliculaEditViewModel _pelicula, IFormFile? foto)
        {
            var pelicula = _context.Peliculas
                                   .Include(p => p.Salas)
                                   .FirstOrDefault(p => p.Id == _pelicula.Id);
            if (pelicula == null)
            {
                throw new InvalidOperationException($"No se encontró la película con Id={_pelicula.Id}");
            }

            pelicula.Titulo = _pelicula.Titulo;
            pelicula.Descripcion = _pelicula.Descripcion;
            pelicula.Genero = _pelicula.Genero;
            pelicula.Anio = _pelicula.Anio;
            pelicula.Duracion = _pelicula.Duracion;
            pelicula.Precio = _pelicula.Precio;

            if ((foto != null) && foto.Length > 0)
            {
                using var ms = new MemoryStream();
                foto.CopyTo(ms);
                pelicula.Foto = ms.ToArray();
                pelicula.FotoMimeType = foto.ContentType;
            }

            var selectedSalaIds = _pelicula.Salas.Where(s => s.Asignada).Select(s => s.Id).ToHashSet();

            var todasLasSalas = _context.Salas.ToList();

            foreach (var sala in todasLasSalas)
            {
                if (selectedSalaIds.Contains(sala.Id))
                {
                    if (sala.PeliculaId != pelicula.Id)
                    {
                        sala.PeliculaId = pelicula.Id;
                    }
                }
                else
                {
                    if (sala.PeliculaId == pelicula.Id)
                    {
                        sala.PeliculaId = null;
                    }
                }
            }

            _context.SaveChanges();
        }
    }
}
