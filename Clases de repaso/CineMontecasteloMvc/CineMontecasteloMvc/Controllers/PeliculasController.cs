using CineMontecasteloMvc.Managers.Interfaces;
using CineMontecasteloMvc.Models;
using CineMontecasteloMvc.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CineMontecasteloMvc.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly IPeliculaManager _peliculaManager;

        public PeliculasController(IPeliculaManager peliculaManager)
        {
            _peliculaManager = peliculaManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            var peliculas = _peliculaManager.GetAll();
            return View(peliculas);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pelicula pelicula, IFormFile? formFile)
        {
         
            if (!ModelState.IsValid)
            {
                return View(pelicula);
            }
            _peliculaManager.Create(pelicula, formFile);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var pelicula = _peliculaManager.GetWithSalas(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pelicula = _peliculaManager.GetById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _peliculaManager.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Cartelera()
        {
            var peliculas = _peliculaManager.GetCartelera();
            return View(peliculas);
        }


        // Obtener la imagen de una película
        public IActionResult Imagen(int id)
        {
            var (imageData, mimeType) = _peliculaManager.GetImagen(id);
            if (imageData != null && mimeType != null)
            {
                return File(imageData, mimeType);
            }
            else
            {
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit( int id)
        {
            var pelicula = _peliculaManager.GetWithSalas(id);
            if (pelicula == null)
            {
                return NotFound();
            }

            var salas = _peliculaManager.GetAllSalas();

            var vm = new ViewModels.PeliculaEditViewModel
            {
                Id = pelicula.Id,
                Titulo = pelicula.Titulo,
                Descripcion = pelicula.Descripcion,
                Genero = pelicula.Genero,
                Anio = pelicula.Anio,
                Duracion = pelicula.Duracion,
                Precio = pelicula.Precio,
                Salas = salas.Select(s => new ViewModels.SalaCheckboxViewModel
                {
                    Id = s.Id,
                    Descripcion = $"{s.Nombre} (aforo {s.Aforo})",
                    Asignada = s.PeliculaId == pelicula.Id,
                }).ToList()
            };
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PeliculaEditViewModel model, IFormFile? formFile)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                var salas = _peliculaManager.GetAllSalas();
                model.Salas = salas.Select(s => new ViewModels.SalaCheckboxViewModel
                {
                    Id = s.Id,
                    Descripcion = $"{s.Nombre} (aforo {s.Aforo})",
                    Asignada = s.PeliculaId == model.Id,
                }).ToList();
                return View(model);
            }

            _peliculaManager.Update(model, formFile);
            return RedirectToAction("Index");
        }

    }
}
