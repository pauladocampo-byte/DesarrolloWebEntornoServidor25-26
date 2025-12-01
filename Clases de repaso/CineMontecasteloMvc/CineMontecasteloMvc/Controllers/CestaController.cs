using CineMontecasteloMvc.Helpers;
using CineMontecasteloMvc.Managers.Interfaces;
using CineMontecasteloMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace CineMontecasteloMvc.Controllers
{
    public class CestaController : Controller
    {
        private readonly IPeliculaManager _peliculaManager; // servicio para obtener películas
        private const string CestaKey = "Cesta"; // clave de sesión donde se guarda la cesta
        public CestaController(IPeliculaManager peliculaManager)
        {
            _peliculaManager = peliculaManager;
        }

        // Añadir una película a la cesta (POST desde formulario)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Agregar(int peliculaId, int cantidad)
        {
            // Buscar película por id; 404 si no existe
            var pelicula = _peliculaManager.GetById(peliculaId);
            if (pelicula == null) return NotFound();

            //// Leer cesta actual de sesión
            var cesta = HttpContext.Session.GetObject<List<CestaItem>>(CestaKey) ?? new List<CestaItem>();

            // Si ya existe el item, acumula cantidad; si no, crea uno nuevo
            var existente = cesta.FirstOrDefault(c => c.PeliculaId == peliculaId);
            if (existente == null)
            {
                cesta.Add(new CestaItem
                {
                    PeliculaId = pelicula.Id,
                    Titulo = pelicula.Titulo,
                    Precio = pelicula.Precio,
                    Cantidad = cantidad
                });
            }
            else
            {
                existente.Cantidad += cantidad;
            }

            //// Guardar cesta actualizada en sesión
            HttpContext.Session.SetObject(CestaKey, cesta);

            // Volver a la cartelera
            return RedirectToAction("Cartelera", "Peliculas");
        }

        // Mostrar la cesta
        public IActionResult Index()
        {
            //var cesta = GetCesta();
            var cesta = HttpContext.Session.GetObject<List<CestaItem>>(CestaKey) ?? new List<CestaItem>();
            return View(cesta);
        }

        // Vaciar la cesta (elimina la clave de sesión)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Vaciar()
        {
            HttpContext.Session.Remove(CestaKey);
            return RedirectToAction(nameof(Index));
        }
    }
}
