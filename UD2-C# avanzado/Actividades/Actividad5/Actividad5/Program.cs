using Actividad5.Consola;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

// Creamos 2 libros y 3 DVDs
var items = new List<Publicacion>
{
    new Libro("El nombre del viento", 19.95m, "Patrick Rothfuss"),
    new Libro("La sombra del viento", 17.50m, "Carlos Ruiz Zafón"),
    new Dvd("Interstellar", 12.99m, 169),
    new Dvd("El Señor de los Anillos: La Comunidad del Anillo", 14.50m, 178),
    new Dvd("Spider-Man: Into the Spider-Verse", 11.95m, 117)
};

// Mostramos tabla en consola (sin HTML, solo texto)
ImprimirTabla(items);

// Demostración teórica: NO se puede crear una Publicacion porque es abstracta.
// Descomentar la línea siguiente para ver el error de compilación:
// var p = new Publicacion("Algo", 1.0m); // ❌ CS0144: No se puede crear una instancia de un tipo abstracto

static void ImprimirTabla(IEnumerable<Publicacion> pubs)
{
    Console.WriteLine(new string('=', 90));
    Console.WriteLine($"{"Tipo",-8} {"Título",-45} {"Precio",8}  {"Detalle",-25}");
    Console.WriteLine(new string('-', 90));

    foreach (var p in pubs)
    {
        Console.WriteLine($"{p.Tipo,-8} {p.InfoBasica()}  {p.InfoEspecifica(),-25}");
    }

    Console.WriteLine(new string('=', 90));
}
