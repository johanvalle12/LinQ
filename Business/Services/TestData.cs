using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public static class TestData
    {
        public static List<Product> ProductList = new List<Product>()
        {
            new Product(1, "Silla", 200, "Una silla negra", "Sillatronic", "s1s2", 10),
            new Product(2, "Mesa", 150, "Una mesa blanca", "Mesatronic", "s2s3", 4),
            new Product(3, "Cama", 500, "Una cama", "Camatronic", "s3s4", 2)
        };

        public static List<Department> DepartmentList = new List<Department>()
        {
                new Department(1,"Alimentos", new List<Subdepartment> {
                new Subdepartment(1,"Salchichoneria"),
                new Subdepartment(2,"Lacteos"),
                new Subdepartment(3,"Panaderia")
            }),
            new Department(2,"Electronica",new List<Subdepartment> {
                new Subdepartment(1,"TV's"),
                new Subdepartment(2,"Celulares"),
                new Subdepartment(3,"Audio")
            }),
            new Department(3,"Muebles",new List<Subdepartment> {
                new Subdepartment(1,"Cocina"),
                new Subdepartment(2,"Comedor"),
                new Subdepartment(3,"Sala")
            })
        };

        public static List<Provider> GetProviders()
        {
            var providers = new List<Provider>();
            var p1 = new Provider(1, "Gamesa", "proveedor@gamesa.com");
            p1.AddAddress("Islas 123", "Mexicali");
            p1.AddPhoneNumber("6861234567");
            providers.Add(p1);

            var p2 = new Provider(2, "Mercado Chuchita", "proveedor@chuchita.com");
            p2.AddAddress("Islas Chu 123", "Ensenada");
            p2.AddPhoneNumber("6461234567");
            providers.Add(p2);

            var p3 = new Provider(3, "Levis", "proveedor@levis.com");
            p3.AddAddress("Islas Levis 123", "Tijuana");
            p3.AddPhoneNumber("6641234567");
            providers.Add(p3);

            return providers;
        }
    }
}
