using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad14
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Introduce el tamaño del array: ");
            int tamaño = int.Parse(Console.ReadLine());

            // Creamos un array de enteros anulables
            int?[] numeros = new int?[tamaño];

            Random rnd = new Random();

            // Rellenamos aleatoriamente algunas posiciones (por ejemplo, la mitad)
            for (int i = 0; i < tamaño / 2; i++)
            {
                int posicion = rnd.Next(0, tamaño); // posición aleatoria
                numeros[posicion] = rnd.Next(1, 11); // valor entre 1 y 10
            }

            // Mostramos el contenido y comprobamos si hay nulos
            Console.WriteLine("\nContenido del array:");
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] is null)
                    Console.WriteLine($"Posición {i}: nulo");
                else
                    Console.WriteLine($"Posición {i}: {numeros[i]}");
            }

            Console.ReadKey();
        }
    }

}
