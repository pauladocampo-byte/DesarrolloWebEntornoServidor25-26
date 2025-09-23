using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad11
{ 

    using System; // Necesario para usar Console y otras funciones básicas

    class Program
    {
        static void Main()
        {
            // 1. Pedimos cuántos números quiere introducir el usuario
            Console.Write("¿Cuántos números quieres introducir? ");
            int cantidad = int.Parse(Console.ReadLine());

            // 2. Creamos un array del tamaño introducido
            int[] numeros = new int[cantidad];

            // 3. Pedimos al usuario que introduzca los números uno a uno
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write("Introduce el número " + (i + 1) + ": ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            // 4. Ordenamos el array de menor a mayor con Sort()
            Array.Sort(numeros);

            // 5. Mostramos el array ordenado
            Console.WriteLine("\nArray ordenado:");
            foreach (int n in numeros)
            {
                Console.Write(n + " ");
            }

            // 6. Pedimos al usuario un número que quiera buscar
            Console.Write("\n\nIntroduce un número para buscar en el array: ");
            int numeroBuscado = int.Parse(Console.ReadLine());

            // 7. Usamos BinarySearch para buscar el número en el array
            int posicion = Array.BinarySearch(numeros, numeroBuscado);

            // 8. Si la posición es mayor o igual que 0, el número existe en el array
            if (posicion >= 0)
            {
                Console.WriteLine("✅ El número está en la posición: " + posicion);
            }
            else
            {
                Console.WriteLine("❌ El número no se encontró en el array.");
            }

            // 9. Esperamos una tecla para finalizar
            Console.ReadKey();
        }
    }

}
