namespace Actividad7A
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numeroIngresado = -1, suma = 0;

            while (numeroIngresado != 0)
            {
                Console.Write("Ingresa un número:");
                int.TryParse(Console.ReadLine(), out numeroIngresado);
                suma += numeroIngresado;
            }

            Console.Write("La suma total es: " + suma);
            Console.ReadKey();
        }
    }
}
