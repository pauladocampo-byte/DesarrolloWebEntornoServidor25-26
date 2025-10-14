namespace Actividad5.Consola;

public abstract class Publicacion
{
    protected Publicacion(string titulo, decimal precio)
    {
        Titulo = titulo;
        Precio = precio;
    }

    public string Titulo { get; init; }
    public decimal Precio { get; init; }

    public abstract string Tipo { get; }
    public abstract string InfoEspecifica();

    public string InfoBasica() => $"{Titulo,-45} {Precio,8:0.00}€";
}
