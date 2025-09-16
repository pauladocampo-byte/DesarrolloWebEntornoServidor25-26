string dni, nombre;
short edad;
int saldo;

Console.WriteLine("Introduzca el DNI");
dni = Console.ReadLine();

Console.WriteLine("Introduzca el nombre");
nombre = Console.ReadLine();

Console.WriteLine("Introduzca la edad");
edad = Convert.ToInt16(Console.ReadLine());

Console.WriteLine("Introduzca el saldo");
saldo = Convert.ToInt32(Console.ReadLine());


Console.WriteLine("Tu Dni es :" + dni + " Tu nombre es " + nombre + " tu edad es " + edad + " Tu saldo es: " + saldo);



