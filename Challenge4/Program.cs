using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };
            // C.1 Write a program in C# Sharp to display the number and frequency of number from given array.
            var result1 = arr1
                .GroupBy(n => n)
                .Select(s => new {Num = s.Key, Frequency = s.Count());

            Console.WriteLine("Ejercicio 1.");
            foreach(var n in result1)
            {
                Console.WriteLine($"El numero {n.Num} aparece {n.Frequency} veces en la lista.");
            }

            // C.2 Write a program in C# Sharp to display a list of unrepeated numbers.
            var result2 = arr1.Distinct().OrderBy(n => n);
            Console.WriteLine("Ejercicio 2. La lista de numeros unicos es la siguiente:");
            foreach (var n in result2)
            {
                Console.WriteLine(n);
            }
            // C.3 Write a program in C# Sharp to display numbers, multiplication of number with frequency and the frequency of number of giving array.
            Console.WriteLine("Ejercicio 3.");
            var result3 = arr1.GroupBy(n => n)
                .Select(s => new { Num = s.Key, Frequency = s.Count(), Mult = s.Key * s.Count() });
            Console.WriteLine(string.Join(", ", arr1));
            foreach (var n in result3)
            {
                Console.WriteLine($"El numero {n.Num} multiplicado por {n.Frequency} (frecuencia) es {n.Mult}.");
            }
            foreach (var n in result3)
            {
                Console.WriteLine($"El numero {n.Num} aparece {n.Frequency} veces en la lista.");
            }

        }
    }
}
