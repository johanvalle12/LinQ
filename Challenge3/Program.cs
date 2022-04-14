using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge3
{
    class Program
    {
        static string[] cities = { "ROME", "LONDON", "NAIROBI", "CALIFORNIA", "ZURICH", "NEW DELHI", "AMSTERDAM", "ABU DHABI", "PARIS" };
        static void Main(string[] args)
        {

            // 8.1 Find the string which starts and ends with a specific character : "AM".
            var AMLambdaExpression = cities
                .Where(city => city.StartsWith("AM") && city.EndsWith("AM"));
            Console.WriteLine("Las ciudades que empiezan y terminan con 'AM' de la lista son:");
            Console.WriteLine(string.Join(", ", AMLambdaExpression));

            // 8.2 Write a program in C# Sharp to display the list of items in the array according the length of the string then by name in ascending order.
            var lengthAscLambdaExpression = cities
                .OrderBy(city => city)
                .GroupBy(city => city.Length)
                .OrderBy(group => group.Key);

            foreach (var tamano in lengthAscLambdaExpression)
            {
                Console.WriteLine($"Ciudades con {tamano.Key} caracteres");
                foreach(var ciudad in tamano)
                {
                    Console.WriteLine(ciudad);
                }
            }
            // 8.3 Write a program in C# Sharp to split a collection of strings into 3 random groups. P E N D I E N T E
            var randomGroupsLambdaExpression = cities
                .GroupBy(city => city.Length % 3)
                .OrderBy(group => group.Key);

            foreach (var tamano in randomGroupsLambdaExpression)
            {
                Console.WriteLine($"Ciudades con length % 3 igual a {tamano.Key}");
                foreach (var ciudad in tamano)
                {
                    Console.WriteLine(ciudad);
                }
            }
        }
    }
}
