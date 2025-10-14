using Actividad3.Clases;

namespace Actividad3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DVD pelicula1 = new DVD("ESDLA: La comunidad del anillo", 20, 180);
            DVD pelicula2 = new DVD();

            Publicacion publi1 = new DVD();

            Console.WriteLine(pelicula1);

            Libro libro1 = new Libro("Harry Potter y la piedra filosofal", 15, "JK Rowling");
            Libro libro2 = new Libro();

            Console.WriteLine(libro1);

            Console.ReadKey();

        }
    }
}
