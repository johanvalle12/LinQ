using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge5
{
    class Program
    {
        private static List<Student> students = new List<Student>
{
            new Student {FirstName="Svetlana", LastName="Omelchenko", ID=111, Scores = new List<int> {97, 92, 81, 60}},
            new Student {FirstName="Claire", LastName="O'Donnell", ID=112, Scores = new List<int> {75, 84, 91, 39}},
            new Student {FirstName="Sven", LastName="Mortensen", ID=113, Scores = new List<int> {88, 94, 65, 91}},
            new Student {FirstName="Cesar", LastName="Garcia", ID=114, Scores = new List<int> {97, 89, 85, 82}},
            new Student {FirstName="Debra", LastName="Garcia", ID=115, Scores = new List<int> {35, 72, 91, 70}},
            new Student {FirstName="Fadi", LastName="Fakhouri", ID=116, Scores = new List<int> {99, 86, 90, 94}},
            new Student {FirstName="Hanying", LastName="Feng", ID=117, Scores = new List<int> {93, 92, 80, 87}},
            new Student {FirstName="Hugo", LastName="Garcia", ID=118, Scores = new List<int> {92, 90, 83, 78}},
            new Student {FirstName="Lance", LastName="Tucker", ID=119, Scores = new List<int> {68, 79, 88, 92}},
            new Student {FirstName="Terry", LastName="Adams", ID=120, Scores = new List<int> {99, 82, 81, 79}},
            new Student {FirstName="Eugene", LastName="Zabokritski", ID=121, Scores = new List<int> {96, 85, 91, 60}},
            new Student {FirstName="Michael", LastName="Tucker", ID=122, Scores = new List<int> {94, 92, 91, 91}}
        };
        static void Main(string[] args)
        {

            // D.1 Get the top student of the list making an average of their scores.
            var bestStudent = students
                .OrderByDescending(student => student.Scores.Average())
                .First();
            Console.WriteLine($"El estudiante mas destacado es: {bestStudent.FirstName} {bestStudent.LastName} con un promedio de {bestStudent.Scores.Average()}.");

            // D.2 Get the student with the lowest average score.
            var worstStudent = students
                .OrderBy(student => student.Scores.Average())
                .First();
            Console.WriteLine($"El estudiante menos destacado es: {worstStudent.FirstName} {worstStudent.LastName} con un promedio de {worstStudent.Scores.Average()}.");
            // D.3 Get the last name of the student that has the ID 117
            var student117 = students
                .Find(student => student.ID == 117).LastName;
            Console.WriteLine($"El apellido del estudiante con el ID 117 es: {student117}.");

            // D.4 Get the first name of the students that have any score more than 90
            var studentMore90 = students
                .Where(student => student.Scores.Any(score => score > 90))
                .Select(s => s.FirstName);
            Console.WriteLine("Los estudiantes que tienen por lo menos un puntaje mayor a 90 son:");
            Console.WriteLine(string.Join(", ", studentMore90));
        }
        public class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int ID { get; set; }
            public List<int> Scores { get; set; }
        }
    }
}
