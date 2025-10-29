using System;
using System.Collections.Generic;

namespace PokemonProyect.Models;

public partial class Pokemon
{
    public int PokemonId { get; set; }

    public string Nombre { get; set; } = null!;

    public double Peso { get; set; }

    public double Altura { get; set; }
}
