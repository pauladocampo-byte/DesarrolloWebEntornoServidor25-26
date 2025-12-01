using CineMontecasteloMvc.Models;
using CineMontecasteloMvc.ViewModels;

namespace CineMontecasteloMvc.Managers.Interfaces
{
    public interface IPeliculaManager
    {
        //Obtenemos todas las peliculas
        List<Pelicula> GetAll();

        //Obtenemos las peliculas en cartelera con las salas asociadas
        List<Pelicula> GetCartelera();

        //Obtenemos una pelicula por id
        Pelicula? GetById(int id);

        //Obtenemos todas las salas
        List<Sala> GetAllSalas();

        //Obtenemos la pelicula con sus salas
        Pelicula GetWithSalas(int id);

        //Creamos una pelicula
        void Create(Pelicula pelicula, IFormFile? foto);

        //Actualizamos una pelicula
        void Update(PeliculaEditViewModel pelicula, IFormFile? foto);

        //Borramos una pelicula
        void Delete(int id);

        //Obtenemos la imagen de una pelicula
        (byte[]? ImageData, string? MimeType) GetImagen(int id);


    }
}
