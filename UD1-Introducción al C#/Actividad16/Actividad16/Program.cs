namespace Actividad16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int montecastelo, cuadrado;
            Console.Write("Introduce un numero: ");
            
            int.TryParse(Console.ReadLine(), out montecastelo);

            cuadrado = calcularCuadrado(montecastelo);

            Console.WriteLine("El cuadrado es: " + cuadrado);

            Console.ReadKey();
        }

        static int calcularCuadrado(int numero)
        {
            int cuadrado;
            cuadrado = numero * numero;
            return cuadrado;
        }
    }
}
