using System;
using System.Collections.Generic;
using System.Linq;


namespace Challenge1
{
    class Program
    {
        // Find the words in the collection that start with the letter 'L'
        static List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

        // Which of the following numbers are multiples of 4 or 6
        static List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

        // Output how many numbers are in this list
        static List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };
        static void Main(string[] args)
        {
            var fruitsLambdaExpression = fruits
                .Where(fruit => fruit[0].Equals('L'));

            Console.WriteLine(string.Join(", ", fruitsLambdaExpression));

            var mixedNumbersLambdaExpression = mixedNumbers
                .Where(number => number % 4 == 0 || number % 6 == 0);

            Console.WriteLine(string.Join(", ", mixedNumbersLambdaExpression));

            var numbersLambdaExpression = numbers.Count();

            Console.WriteLine($"Hay {numbersLambdaExpression} numeros");
        }
    }
}
