
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        
        private void MenuReportes()
        {
            Console.Clear();
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1.- Top 5 de productos mas caros ordenados por precio más alto.");
            Console.WriteLine("2.- Productos con 5 unidades o menos ordenados por stock.");
            Console.WriteLine("3.- Nombre de productos por marcas ordenados por nombre.");
            Console.WriteLine("4.- Agrupacion de departamentos con subdepartamento y nombres de productos.");
            Console.WriteLine("5.- Regresar.");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Top5ProductosMasCaros();
                        break;
                    }
                case "2":
                    {
                        Productos5UnidadesOMenos();
                        break;
                    }
                case "3":
                    {
                        ProductosPorMarca();
                        break;
                    }
                case "4":
                    {
                        DepartamentoSubdepartamentosProductos();
                        break;
                    }
                default:
                    return;
            }
        }

        private void Top5ProductosMasCaros()
        {
            var result = _reportService.Top5ProductosMasCaros();
            Console.WriteLine("Top 5 productos mas caros.");

            foreach (var p in result)
            {
                Console.WriteLine($"{p.Name} - {p.Price}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void Productos5UnidadesOMenos()
        {
            var result = _reportService.Productos5UnidadesOMenos();
            Console.WriteLine("Productos con 5 unidades o menos.");

            foreach (var p in result)
            {
                Console.WriteLine($"{p.Name} - {p.Stock}");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void ProductosPorMarca()
        {
            //var productos = _productService.GetProducts();
            //var result = productos
            //    .OrderBy(producto => producto.Name)
            //    .GroupBy(producto => producto.Brand)
            //    .OrderBy(group => group.Key);

            var result = _reportService.ProductosPorMarca();

            Console.WriteLine("Productos por marca");

            foreach (var marca in result)
            {
                Console.WriteLine(marca.Brand);
                foreach (var producto in marca.Products)
                {
                    Console.WriteLine(producto.Name);
                }
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void DepartamentoSubdepartamentosProductos()
        {
            var departments = _departmentService.GetDepartments();

            foreach (var department in departments)
            {
                Console.WriteLine($"Departamento: {department.Name}");
                foreach (var subdepartment in department.Subdepartments)
                {
                    Console.WriteLine($"Subdepartmento: {subdepartment.Name}");
                    foreach (var product in subdepartment.Products)
                    {
                        Console.WriteLine(product.ToString());
                    }
                }
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }
}
