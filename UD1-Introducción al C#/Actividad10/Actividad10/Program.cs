using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad9
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("¿Cuántos números quieres introducir?: ");
            int cantidad = int.Parse(Console.ReadLine());

            int[] numeros = new int[cantidad];

            // Lectura de los números
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write("Introduce el número " + (i + 1) + ": ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            // Ordenar de menor a mayor
            Array.Sort(numeros);
            Console.WriteLine("\nNúmeros ordenados de menor a mayor:");
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write(numeros[i] + " ");
            }

            // Invertir el orden
            Array.Reverse(numeros);
            Console.WriteLine("\n\nNúmeros en orden inverso:");
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write(numeros[i] + " ");
            }

            Console.WriteLine("\n\nPulsa una tecla para salir.");
            Console.ReadKey();
        }
    }
}
