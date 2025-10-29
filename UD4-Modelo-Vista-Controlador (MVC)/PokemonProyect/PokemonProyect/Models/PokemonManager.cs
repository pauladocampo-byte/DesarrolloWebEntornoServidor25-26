namespace PokemonProyect.Models
{
    public class PokemonManager
    {
        private readonly PokemonContext _context;
        public PokemonManager(PokemonContext context)
        {
            _context = context;
        }
        public IEnumerable<Pokemon> GetAllPokemons()
        {
            return _context.Pokemons.ToList();
        }
        public Pokemon? Buscar(int id)
        {
            return _context.Pokemons.FirstOrDefault(p => p.PokemonId == id);
        }

        public IEnumerable<Pokemon>GetPokemonByPesoAltura(float peso, float altura)
        {
            return _context.Pokemons
                .Where(p => Math.Round(p.Peso,2) == Math.Round(peso,2) 
                        && Math.Round(p.Altura,2) == Math.Round(altura,2))
                .ToList();
        }

        public void Actualizar(Pokemon pokemon)
        {
            _context.Pokemons.Update(pokemon);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var pokemon = Buscar(id);
            if (pokemon == null) return false;
            _context.Pokemons.Remove(pokemon);
            _context.SaveChanges();
            return true;
        }

        public void Agregar(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();
        }
    }
}
