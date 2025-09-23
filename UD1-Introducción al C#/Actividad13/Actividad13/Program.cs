﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad13
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("¿Cuántos nombres quieres ingresar? ");
            int cantidad = int.Parse(Console.ReadLine());

            string[] nombres = new string[cantidad];

            // Pedimos los nombres y los guardamos en el array
            for (int i = 0; i < cantidad; i++)
            {
                Console.Write($"Nombre {i + 1}: ");
                nombres[i] = Console.ReadLine();
            }

            Console.WriteLine("\nNombres ingresados:");

            // Mostramos todos los nombres usando foreach
            foreach (string nombre in nombres)
            {
                Console.WriteLine(nombre);
            }

            Console.ReadKey();
        }
    }
}
