using DapperProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperProject.Controllers
{
    public class FabricanteController : Controller
    {
            private readonly IFabricanteRepository _fabricanteRepository;

            public FabricanteController(IFabricanteRepository fabricanteRepository)
            {
                _fabricanteRepository = fabricanteRepository;
            }

            public IActionResult Index()
            {
                return RedirectToAction(nameof(GetAll));
            }

            [HttpGet]
            public IActionResult GetAll()
            {
                // Creo la lista y la cargo desde el repositorio
                List<Fabricante> listaFabricantes = _fabricanteRepository
                                                    .GetFabricantes()
                                                    .ToList();

                // Le paso la lista a la vista
                return View(listaFabricantes);
            }

            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Fabricante fabricante)
            {
                // Llamo al modelo, inserto un fabricante
                _fabricanteRepository.CrearFabricante(fabricante);
                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public IActionResult Edit(int codigo)
            {
                // Llamo al modelo, obtengo un fabricante
                var fab = _fabricanteRepository.GetFabricante(codigo);
                if (fab == null) return NotFound();

                return View(fab);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(Fabricante fab)
            {
                // Llamo al modelo, actualizo un fabricante
                _fabricanteRepository.UpdateFabricante(fab);
                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public IActionResult Delete(int codigo)
            {
                // Llamo al modelo, obtengo un fabricante
                var fab = _fabricanteRepository.GetFabricante(codigo);
                if (fab == null) return NotFound();

                return View(fab);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Delete(Fabricante fab)
            {
                // Llamo al modelo, borro un fabricante
                _fabricanteRepository.DeleteFabricante(fab.Codigo);
                return RedirectToAction(nameof(Index));
            }

            [HttpGet]
            public IActionResult Details(int codigo)
            {
                // Llamo al modelo, obtengo un fabricante
                var fab = _fabricanteRepository.GetFabricante(codigo);
                if (fab == null) return NotFound();

                return View(fab);
            }
    }
}
