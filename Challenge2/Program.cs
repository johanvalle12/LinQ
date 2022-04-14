using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenge2
{
    class Program
    {
        static List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
        static void Main(string[] args)
        {
            // Mostrar cuantos millonarios hay por banco. Millonario -> >= 1000000 
            var millonariosPorBancoLambdaExpression = customers
                .Where(customer => customer.Balance > 1000000)
                .GroupBy(customer => customer.Bank);
            Console.WriteLine("Millonario por banco.");
            foreach (var banco in millonariosPorBancoLambdaExpression)
            {
                Console.WriteLine($"En el banco {banco.Key} hay {banco.Count()} millonarios");
            }

            // Mostrar a los clientes que su balance sea mayor a 100,000
            var balanceMayor100KLambdaExpression = customers
                .Where(customer => customer.Balance > 100000);
            
            Console.WriteLine($"\nLos clientes que tienen balance mayor a 100,000 son:");
            foreach (var customer in balanceMayor100KLambdaExpression)
            {
                Console.WriteLine($"{customer.Name} Balance: {customer.Balance}");
            }

            // Ordenar a los clientes por su balance.
            var customersPorBalanceLambdaExpression = customers
                .OrderBy(customer => customer.Balance);
            Console.WriteLine($"\nLos clientes ordenados por balance (menor a mayor):");
            foreach (var customer in customersPorBalanceLambdaExpression)
            {
                Console.WriteLine($"{customer.Name} Balance: {customer.Balance}");
            }
            // Hacer sumatoria por riqueza de cada banco.
            var riquezaPorBancoLambdaExpression = customers
                .GroupBy(customer => customer.Bank)
                .Select(group => new
                {
                    Banco = group.Key,
                    Riqueza = group.Sum(customer => customer.Balance)
                });
            Console.WriteLine($"\nRiqueza por banco.");
            foreach (var banco in riquezaPorBancoLambdaExpression)
            {
                Console.WriteLine($"Banco: {banco.Banco} Riqueza: {banco.Riqueza} ");
            }

            // Obtener el nombre de los clientes que su balance sea menor a 100,000 y su banco tenga solo 3 caracteres.
            var clientesMenorA100KLambdaExpression = customers
                .Where(customer => customer.Balance < 100000 && customer.Bank.Length == 3);

            Console.WriteLine($"\nLos clientes que tienen balance menor a 100,000 y banco con 3 caracteres son:");
            Console.WriteLine($"Name\t\tBalance\t\tBanco");
            foreach (var customer in clientesMenorA100KLambdaExpression)
            {
                Console.WriteLine($"{customer.Name}\t{customer.Balance}\t{customer.Bank}");
            }
        }
    }

    class Customer
    {
        public string Name { get; internal set; }
        public double Balance { get; internal set; }
        public string Bank { get; internal set; }
    }
}
