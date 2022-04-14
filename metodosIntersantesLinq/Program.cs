using System;
using System.Collections.Generic;
using System.Linq;
using VariosMetodosInteresantes;

namespace metodosIntersantesLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            // Distinct retorna una lista de elementos unicos, es decir, solo agrega una vez a la lista aquellos elementos repetidos.
            int[] factoriales = { 2, 2, 3, 5, 5 };
            int factorialesUnicos = factoriales.Distinct().Count();
            Console.WriteLine($"Hay {factorialesUnicos} factoriales unicos");

            // Para sumar elementos
            int[] numbers = { 5, 3, 6, 2, 6, 21 };
            double numSum = numbers.Sum();
            Console.WriteLine($"La suma de los elementos es: {numSum}");

            // Para encontrar el valor mas chico y mas grande de una lista de enteros
            int minNum = numbers.Min();
            int maxNum = numbers.Max();

            Console.WriteLine($"El valor mas chico de la lista es: {minNum}");
            Console.WriteLine($"El valor mas grande de la lista es: {maxNum}");

            // Proyecciones en min y max, al parecer con proyeccion se refieren a cuando se trabaja con listas de strings y se utiliza el length de cada string como valor numerico.

            string[] words = { "cherry", "apple", "banana" };
            int shortestWord = words.Min(w => w.Length);
            int longestWord = words.Max(w => w.Length);

            Console.WriteLine($"La palabra mas corta tiene {shortestWord} caracteres");
            Console.WriteLine($"La palabra mas larga tiene {shortestWord} caracteres");

            // Promedio de una lista de enteros
            double averageNum = numbers.Average();

            // Proyecciones en average
            double averageLength = words.Average(w => w.Length);
            Console.WriteLine($"El promedio de caracteres es: {averageLength}");

            // Conversion de listas
            double[] doubles = { 1.4, 5.3, 6.2, 2.1, 0.4 };
            var sortedDoubles = doubles.OrderBy(d => d);

            var doublesList = sortedDoubles.ToList();
            foreach (var d in doublesList)
                Console.WriteLine(d);

            // Conversion de arreglos
            var doublesArray = sortedDoubles.ToArray();
            for (int i = 0; i < doublesArray.Length; i++)
            {
                Console.WriteLine(doublesArray[i]);
            }

            // Conversion a diccionario
            var scoreRecord = new[]
            {
                new {Name = "Alice", Score = 50},
                new {Name = "Bob", Score = 40},
                new {Name = "Charlie", Score = 45}
            };

            // Un diccionario es una coleccion de llave y valor.
            var scoreRecordDict = scoreRecord.ToDictionary(sr => sr.Name);

            Console.WriteLine("Bob's Score {0}", scoreRecordDict["Bob"]);

            // Extraer datos de un tipo
            object[] numbersObjects = { null, 1.0m, "two", 3, "four", 5, "six", 7.0d };

            var doublesObjects = numbersObjects.OfType<double>();
            Console.WriteLine("Valores guardados como dobles");
            foreach(var d in doublesObjects)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("Valores guardados como string");
            var stringsObjects = numbersObjects.OfType<string>();
            foreach (var s in stringsObjects)
            {
                Console.WriteLine(s);
            }

            // Obtener un elemento del listado.
            string[] strings = { "zero", "one", "two", "three", "four", "five"};

            var theFirstOne = strings.First();
            var theOne = strings.First(c => c == "one");

            Console.WriteLine($"El primer elemento de la lista es: {theFirstOne}");
            Console.WriteLine($"Se obtiene el elemento '{theOne}' de la lista");

            // Tal vez exista un elemento del listado.
            string[] strings2 = { };
            var maybeTheFirstOne = strings2.FirstOrDefault();
            Console.WriteLine(maybeTheFirstOne);

            // Si el listado no tiene valores se le asignará el valor hola
            var maybeTheFirstOne2 = strings2.DefaultIfEmpty("hola").First();
            Console.WriteLine(maybeTheFirstOne2);

            // Obtener un elemento de una posicion especifica de una lista.
            var InPosition = numbers.ElementAt(2);
            Console.WriteLine($"El elemento de la posicion 2 del arreglo numbers es: {InPosition}");

            // Ordenamiento de listados
            var sortedStringAsc = strings.OrderBy(c => c);
            var sortedStringDesc = strings.OrderByDescending(c => c);
            var sortedMultipledTimes = strings
                .OrderBy(c => c[0])
                .ThenBy(c => c.Length);

            Console.WriteLine("El orden ascendente de la lista es: ");
            foreach(var s in sortedStringAsc)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("El orden descendente de la lista es: ");
            foreach (var s in sortedStringDesc)
            {
                Console.WriteLine(s);
            }

            // Ordena una listado al revés
            var sortedReverse = strings.Reverse();
            Console.WriteLine("El orden al reves de la lista es: ");
            foreach (var s in sortedReverse)
            {
                Console.WriteLine(s);
            }

            // Particiones en una lista
            // Take(n), toma n cantidad de valores que se le indiquen.
            int[] numbers4 = { 5, 4, 1, 8, 6, 4, 9, 0 };
            var first3Numbers = numbers4.Take(3);

            Console.WriteLine("Los primeros 3 numeros de la lista son:");
            foreach(var number in first3Numbers)
            {
                Console.WriteLine(number);
            }

            // TakeWhile(lambda expression), toma la cantidad de valores que cumplan con la condicion de la lambda expression
            var takeWhile = numbers4.TakeWhile(c => c > 3);
            Console.WriteLine("Los numeros mayores a 3 son:");
            foreach (var number in first3Numbers)
            {
                Console.WriteLine(number);
            }

            // Skip(n), "evita" o "evade" los primeros n elementos que se le indiquen
            var allButFirst4Numbers = numbers4.Skip(4);
            Console.WriteLine("Los numeros despues del cuarto elemento son:");
            foreach (var number in allButFirst4Numbers)
            {
                Console.WriteLine(number);
            }

            // SkipWhile(lambda expression), "evita" o "evade" todos los elementos que cumplan con la condicion de la lambda expression.
            var skipWhile = numbers4.SkipWhile(c => c > 2);
            Console.WriteLine("Los numeros que son menores a 2:");
            foreach (var number in skipWhile)
            {
                Console.WriteLine(number);
            }

            // Proyecciones 
            // Creamos un listado a partir de una clase anonima
            var selectList = strings.Select(c => new { Length = c.Length, Word = c });
            // Creamos un listado a partir de una clase definida.
            var selectListWithEntity = strings.Select(c => new MyWord(c.Length, c));

            foreach(var str in selectListWithEntity)
            {
                Console.WriteLine($"La palabra {str} tiene {str} caracteres");
            }

            // Contains
            // Regresa un booleano si la condicion se cumple
            var siExisteZero = strings.Contains("zero");

            // Any se cumple si cualquier elemento es igual a 'three'
            var esEqualAThree = strings.Any(c => c.Equals("three"));

            // Concat para concatenar dos listas del mismo tipo de dato.
            int[] nums1 = { 1, 2, 3 };
            int[] nums2 = { 4, 5, 6 };
            
            foreach(var n in nums1.Concat(nums2))
            {
                Console.WriteLine(n);
            }
        }
    }
}
