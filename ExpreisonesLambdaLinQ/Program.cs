using System;
using System.Linq;
using System.Threading.Tasks;

namespace ExpreisonesLambdaLinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Function recibe y retorna valores
            Func<int, int> square = x => x * x;

            // Action solo recibe valores
            Action<string> action = x => Console.WriteLine(x);

            Console.WriteLine(square(5));
            action("Hola Mundo");

            int[] numbers = { 1, 3, 5, 8 };
            var squaredNumbers = numbers.Select(x => x * x);

            Console.WriteLine(String.Join(",", squaredNumbers));

            // Los actions tambien pueden declararse sin variables de entrada
            Action line = () => Console.WriteLine("Hola");

            Func<int, int, string> IsTooLong = (x, y) => x > y ? "es mayor" : "es menor";

            // A partir de C# 7
            var tuplas = MisTuplas();
            Console.WriteLine(tuplas.EsCorrecto + " Mensaje: " + tuplas.Mensaje);

            Func<int, int, (bool, string)> MiFunc = (x, y) => (x > y, "Mi mensaje");
            Func<int, int, (bool EsCorrecto, string Mensaje)> MiFunc2 = (x, y) => (x > y, "Mi mensaje");

            var aux = MiFunc2(1, 2);
            Console.WriteLine(aux.Mensaje);

            // Se pueden usar delegados con parametros descartados (C# 9)
            Func<int, int, int> constant = (_, _) => 42;
            Action<int, int> constant2 = (_, _) => Console.WriteLine(43);

            // Un Action con serie de declaraciones
            Action<int> miAccionAsincrona = miParametro =>
            {
                Task.Delay(2000);
                Console.WriteLine("Me espere 2000 milisegundos");
            };

            Console.WriteLine(IsTooLong(20, 15));
            Console.WriteLine(IsTooLong2(20, 15));
        }

        public static string IsTooLong2(int x, int y) => (x > y) ? "Es mayor" : "Es Menor";

        public static (bool EsCorrecto, string Mensaje) MisTuplas()
        {
            return (true, "Mensaje de Prueba");
        }
    }
}
