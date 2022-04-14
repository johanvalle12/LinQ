using System;
using System.Collections.Generic;
using System.Linq;

namespace LinQPrimerDia
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
            // Ejemplo de linq en un arreglo
            int[] scores = { 94, 70, 95, 67, 86 };
            IEnumerable<int> scoreQuery = from score in scores
                             where score > 70
                             select score;

            //foreach(var i in scoreQuery)
            //{
            //    Console.Write(i + " ");
            //}

            var scoreQuery2 = from score in scores
                             where score > 70
                             select score * score;

            //foreach (var i in scoreQuery2)
            //{
            //    Console.Write(i + " ");
            //}
            // Se termina el ejemplo anterior

            // Usando linq para objects en formato query expression
            var studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Scores[0] descending
                select student;

            foreach(var student in studentQuery)
            {
                Console.WriteLine(student.FirstName + " " + student.LastName + " " + student.Scores[0]);
            }

            // Tambien se pueden agrupar los elementos del listado utilizando group by
            var studentQuery2 =
               from student in students
               group student by student.LastName[0]
               into studentGroup
               orderby studentGroup.Key
               select studentGroup;

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach(var student in studentGroup)
                {
                    // Usamos interpolacion de strings
                    Console.WriteLine($"Nombre: {student.FirstName} Apellido: {student.LastName}");

                    // Sin Interpolacion de strings
                    //Console.WriteLine("Nombre: " + student.FirstName + " Apellido: " + student.LastName);
                }
            }

            // Se puede utilziar linq para realizar operaciones dentro de la comparacion y ademas regresar el valor deseado ya formateado.
            IEnumerable<string> studentQuery3 = from student in students
                                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                where totalScore / 4 < student.Scores[0]
                                select $"{student.FirstName} {student.LastName}";

            foreach(var student in studentQuery3)
            {
                Console.WriteLine(student);
            }

            IEnumerable<string> studentQuery4 = from student in students
                                                let totalScore = student.Scores.Sum() // Sum() es lo mismo que student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                                                where totalScore / 4 < student.Scores[0]
                                                select $"{student.FirstName} {student.LastName}";

            IEnumerable<string> studentQuery5 = from student in students
                                                let totalScore = student.Scores.Average() // Suma todos los elementos y saca su promedio.
                                                where totalScore< student.Scores[0]
                                                select $"{student.FirstName} {student.LastName}";

            // Sacar el promedio general de toda la clase
            var promedio = students.Average(student => student.Scores.Average());

            var lastName = "Garcia";
            var studentQuery6 = from student in students
                                where student.LastName.Equals(lastName)
                                select student.FirstName;

            Console.WriteLine("Todos los Garcia de la clase son:");
            Console.WriteLine(string.Join(", ", studentQuery6));

            // Podemos crear tambien nuevos objetos a partir de nuestra consulta
            var studentQuery7 = from student in students
                               let totalScore = student.Scores.Sum()
                               where totalScore > promedio
                               select new { Id = student.ID, Score = totalScore };

            foreach(var item in studentQuery7)
            {
                Console.WriteLine($"Student id: {item.Id} Score: {item.Score}");
            }
        }
    }

    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
        public List<int> Scores { get; set; }
    }
}
