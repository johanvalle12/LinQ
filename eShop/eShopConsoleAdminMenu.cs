using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace eShop
{
    public partial class eShopConsole
    {
        private void AdminMenu()
        {
            var exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Menu de Administrador.");
                Console.WriteLine("Elige una opcion");
                Console.WriteLine("1.- Agregar Producto.");
                Console.WriteLine("2.- Editar Producto.");
                Console.WriteLine("3.- Consultar Productos.");
                Console.WriteLine("4.- Consultar Producto.");
                Console.WriteLine("5.- Eliminar Producto.");
                Console.WriteLine("6.- Reportes.");
                Console.WriteLine("7.- Orden de Compra.");
                Console.WriteLine("8.- Regresar.");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            AgregarProducto();
                            break;
                        }
                    case "2":
                        {
                            EditarProducto();
                            break;
                        }
                    case "3":
                        {
                            ConsultarProductos();
                            break;
                        }
                    case "4":
                        {
                            ConsultarProducto();
                            break;
                        }
                    case "5":
                        {
                            EliminarProducto();
                            break;
                        }
                    case "6":
                        {
                            MenuReportes();
                            break;
                        }
                    case "7":
                        {
                            MenuOrdenDeCompra();
                            break;
                        }
                    default:
                        {
                            exit = false;
                            break;
                        }
                }
            }
        }

        private void AgregarProducto()
        {
            Console.WriteLine("Agrega los valores necesarios para registrar un producto.");
            Console.WriteLine("Id:");
            var id = Console.ReadLine();
            Console.WriteLine("Nombre:");
            var name = Console.ReadLine();
            Console.WriteLine("Precio:");
            var price = Console.ReadLine();
            Console.WriteLine("Descripcion:");
            var description = Console.ReadLine();
            Console.WriteLine("Marca:");
            var brand = Console.ReadLine();
            Console.WriteLine("SKU:");
            var sku = Console.ReadLine();
            var subdepartment = SolicitarSubdepartamento();

            try
            {
                if (!int.TryParse(id, out var idAux))
                    throw new ApplicationException("No se pudo castear el Id correctamente.");

                if (!decimal.TryParse(price, out var priceAux))
                    throw new ApplicationException("El precio es invalido.");

                var product = new Product(idAux, name, priceAux, description, brand, sku);
                product.AddSubdepartment(subdepartment);
                _productService.AddProduct(product);
                Console.WriteLine("Producto agregado correctamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void ConsultarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a consultar:");
            var id = Console.ReadLine();

            try
            {
                if (!int.TryParse(id, out var idAux))
                    throw new ApplicationException("No se pudo castear el Id correctamente.");

                var product = _productService.GetProduct(idAux);
                Console.WriteLine($"Producto: {product.Name}\nPrecio: {product.Price}\nDescripcion: {product.Description}\nMarca: {product.Brand}\nSKU: {product.Sku}\nCantidad: {product.Stock}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void ConsultarProductos()
        {
            try
            {
                var products = _productService.GetProducts();
                Console.WriteLine($"Id\tProducto\tMarca\tSKU\tMarca\tStock\tDescripcion\tDepartamento\tSubdepartamento");
                foreach (var p in products)
                {
                    Console.WriteLine(p.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void EditarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a modificar:");
            var id = Console.ReadLine();

            try
            {
                if (!int.TryParse(id, out var idAux))
                    throw new ApplicationException("No se pudo castear el Id correctamente.");

                var product = _productService.GetProduct(idAux);
                Console.WriteLine($"Producto: {product.Name}\nPrecio: {product.Price}\nDescripcion: {product.Description}\nMarca: {product.Brand}\nSKU: {product.Sku}\nCantidad: {product.Stock}");

                Console.WriteLine("Ingrese los valores por los que se modificara el producto. (Dejar en blanco si no desea modificar algun valor)");
                Console.WriteLine("Nombre:");
                var name = Console.ReadLine();
                Console.WriteLine("Precio:");
                var price = Console.ReadLine();
                Console.WriteLine("Descripcion:");
                var description = Console.ReadLine();
                Console.WriteLine("Marca:");
                var brand = Console.ReadLine();
                Console.WriteLine("SKU:");
                var sku = Console.ReadLine();
                try
                {
                    decimal priceAux;
                    if (price != "")
                    {
                        priceAux = Convert.ToDecimal(price);
                        if (priceAux == 0)
                            throw new ApplicationException("El precio es invalido.");
                    }
                    else
                        priceAux = product.Price;

                    name = (name != "") ? name : product.Name;
                    description = (description != "") ? description : product.Description;
                    brand = (brand != "") ? brand : product.Brand;
                    sku = (sku != "") ? sku : product.Sku;

                    var productAux = new Product(product.Id, name, priceAux, description, brand, product.Sku, product.Stock);
                    _productService.UpdateProduct(product, productAux);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void EliminarProducto()
        {
            Console.WriteLine("Ingrese el ID del producto a eliminar:");
            var id = Console.ReadLine();

            try
            {
                if (!int.TryParse(id, out var idAux))
                    throw new ApplicationException("No se pudo castear el Id correctamente.");
                _productService.DeleteProduct(idAux);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private Subdepartment SolicitarSubdepartamento()
        {
            Console.WriteLine("Elige el departmanto:");
            // mostrar los departamentos.
            var departments = _departmentService.GetDepartments();
            foreach (var d in departments)
            {
                Console.WriteLine($"{d.Id}.- {d.Name}");
            }
            // elegir un departamento.
            var departmentId = Console.ReadLine();
            var department = _departmentService.GetDepartment(GetNumber(departmentId));
            Console.WriteLine("Elige un subdepartamento:");
            // mostrar los subdepartamentos.
            foreach (var sub in department.Subdepartments)
            {
                Console.WriteLine($"{sub.Id}.- {sub.Name}");
            }
            // elegir un subdepartamento.
            var subdepartmentId = Console.ReadLine();
            var subdepartment = _departmentService.GetSubdepartment(department, GetNumber(subdepartmentId));
            subdepartment.Department = department;
            // agregar subdepartamento a producto
            return subdepartment;
        }

        private int GetNumber(string num)
        {
            var numAux = Convert.ToInt32(num);
            if (numAux == 0)
                throw new ApplicationException("El precio es invalido.");

            return numAux;
        }
    }
}
