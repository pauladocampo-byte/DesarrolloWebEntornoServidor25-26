using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad12
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            int cantidad;

            Console.Write("¿Cuántos números quieres ingresar? ");
            int.TryParse(Console.ReadLine(), out cantidad);

            // Creamos el array original con el tamaño introducido
            int[] original = new int[cantidad];

            // Pedimos al usuario que introduzca los números
            for (int i = 0; i < original.Length; i++)
            {
                Console.Write($"Introduce el número {i + 1}: ");
                int.TryParse(Console.ReadLine(), out original[i]);
            }

            // Creamos el array copia con el mismo tamaño
            int[] copia = new int[original.Length];

            // Copiamos los elementos del array original al array copia
            Array.Copy(original, copia, original.Length);

            // Mostramos ambos arrays
            Console.WriteLine("\nArray original:");
            foreach (int numero in original)
            {
                Console.Write(numero + " ");
            }

            Console.WriteLine("\n\nArray copia:");
            foreach (int numero in copia)
            {
                Console.Write(numero + " ");
            }

            Console.ReadLine(); // Para pausar al final
        }
    }
}


