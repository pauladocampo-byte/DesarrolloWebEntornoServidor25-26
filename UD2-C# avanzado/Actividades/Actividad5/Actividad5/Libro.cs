namespace Actividad5.Consola;

public sealed class Libro : Publicacion
{
    public Libro(string titulo, decimal precio, string autor) : base(titulo, precio)
    {
        Autor = autor;
    }

    public string Autor { get; init; }

    public override string Tipo => "Libro";
    public override string InfoEspecifica() => $"Autor: {Autor}";
}
