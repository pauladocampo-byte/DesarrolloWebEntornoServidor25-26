using Microsoft.AspNetCore.Mvc;
using PokemonProyect.Models;

namespace PokemonProyect.Controllers
{
    public class PokemonController : Controller
    {
        private PokemonManager _pokemonManager;
        public PokemonController(PokemonManager pokemonManager)
        {
            _pokemonManager = pokemonManager;
        }
        public IActionResult Index()
        {
            var pokemons = _pokemonManager.GetAllPokemons();
            return View(pokemons);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var pokemon = _pokemonManager.Buscar(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }

        public IActionResult GetPokemons(float peso, float altura)
        {
            var pokemons = _pokemonManager.GetPokemonByPesoAltura(peso, altura);
            return View("Index", pokemons);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var post = _pokemonManager.Buscar(id);
            if (post == null) return NotFound();
            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(int id, Pokemon pokemon)
        {
            if (id != pokemon.PokemonId)
            {
                return BadRequest();
            }
            _pokemonManager.Actualizar(pokemon);
            TempData["Msg"] = "Pokemon actualizado correctamente ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var pokemon = _pokemonManager.Buscar(id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return View(pokemon);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var ok = _pokemonManager.Delete(id);
            if (!ok)
            {
                return NotFound();
            }
            TempData["Msg"] = "Pokemon eliminado correctamente ";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Pokemon pokemon)
        {
            if (!ModelState.IsValid)
            {
                return View(pokemon);
            }
            _pokemonManager.Agregar(pokemon);
            TempData["Msg"] = "Pokemon agregado correctamente ";
            return RedirectToAction("Index");
        }
    }
}
