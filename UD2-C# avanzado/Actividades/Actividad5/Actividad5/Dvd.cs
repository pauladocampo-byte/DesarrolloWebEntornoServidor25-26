namespace Actividad5.Consola;

public sealed class Dvd : Publicacion
{
    public Dvd(string titulo, decimal precio, int duracionMin) : base(titulo, precio)
    {
        DuracionMin = duracionMin;
    }

    public int DuracionMin { get; init; }

    public override string Tipo => "DVD";
    public override string InfoEspecifica() => $"Duración: {DuracionMin} min";
}
