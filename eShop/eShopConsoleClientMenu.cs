using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Services;
using Data.Entities;

namespace eShop
{
    public partial class eShopConsole
    {
        private void ClientMenu()
        {
            var exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Menu de cliente.");
                Console.WriteLine("Elige una opcion");
                Console.WriteLine("1.- Agregar productos al carrito.");
                Console.WriteLine("2.- Eliminar productos del carrito.");
                Console.WriteLine("3.- Consultar carrito.");
                Console.WriteLine("4.- Hacer un pedido.");
                Console.WriteLine("5.- Consultar pedidos.");
                Console.WriteLine("6.- Reporte total gastado.");
                Console.WriteLine("7.- Regresar.");


                // Crear la clase parcial para las ordenes de compra.
                // Registrar una orden de compra donde se pida un proveedor y un listado de productos.
                // Crear un nuevo objeto tipo producto que va a tener lo mismo que nuestro listado de productos actual, modificando solo el valor de stock de los productos lo cual indicara la cantidad de unidades que se compraron de cada producto.

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            AgregarProductoCarrito();
                            break;
                        }
                    case "2":
                        {
                            EliminarProductoCarrito();
                            break;
                        }
                    case "3":
                        {
                            ConsultarCarrito();
                            break;
                        }
                    case "4":
                        {
                            HacerPedido();
                            break;
                        }
                    case "5":
                        {
                            ConsultarPedido();
                            break;
                        }
                    case "6":
                        {
                            ReporteTotalGastado();
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

        public void EliminarProductoCarrito()
        {
            var exit = true;
            while (exit)
            {
                Console.Clear();
                // Verificamos si el carrito cuenta con productos
                if (_carritoService.GetProducts().Count == 0)
                {
                    Console.WriteLine("No hay productos en el carrito actualmente.");
                    exit = false;
                }
                else
                {
                    Console.WriteLine("Los productos que hay en el carrito son:\n");
                    Console.WriteLine($"Id\tNombre\tCantidad\tPrecio\tCosto");
                    foreach (var p in _carritoService.GetProducts())
                    {
                        Console.WriteLine($"{p.Id}\t{p.Name}\t{p.Stock}\t\t{p.Price}\t{p.Price * p.Stock}");
                    }
                    Console.WriteLine("Ingrese el id del producto que desea eliminar");
                    var index = GetNumber(Console.ReadLine());
                    var product = _carritoService.GetProduct(index);
                    // Se verifica que el producto a eliminar exista en el carrito
                    if (product == null)
                        Console.WriteLine("El producto no fue encontrado.");
                    else
                    {
                        // Si existe se elimina el producto del carrito
                        _carritoService.DeleteProduct(product.Id);
                        // Se actualiza el stock del producto en la lista de productos que están a la venta ya que este producto al final no se compró.
                        var indice = TestData.ProductList.FindIndex(p => p.Id == product.Id);
                        var productInList = TestData.ProductList.Find(p => p.Id == product.Id);
                        TestData.ProductList.ElementAt(indice).SetStock(productInList.Stock + product.Stock);
                        Console.WriteLine("Producto eliminado correctamente.");
                    }
                    Console.WriteLine("¿Desea elininar más productos? (S/N)");
                    exit = Console.ReadLine().ToUpper() == "S" ? true : false;
                }
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        public void AgregarProductoCarrito()
        {
            var ActualProducts = TestData.ProductList;
            var exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Lista de productos a la venta.");
                foreach(var p in  ActualProducts)
                {
                    Console.WriteLine($"{p.Id}.- {p.Name} - Costo: {p.Price} - {p.Stock} unidades");
                }
                Console.WriteLine("Ingrese el numero del producto que desea comprar.");
                var productId = Console.ReadLine();
                var product = ActualProducts.FirstOrDefault(p => p.Id == GetNumber(productId));

                if (product == null)
                    Console.WriteLine("El producto no fue encontrado.");
                else
                {
                    Console.WriteLine($"Cuantas unidades de {product.Name} desea comprar:");
                    var cantidad = GetNumber(Console.ReadLine());
                    // Verificamos que la cantidad de unidades a comprar no sea mayor a la que hay en stock.
                    if (product.Stock < cantidad)
                        Console.WriteLine("La cantidad de unidades a comprar no puede ser mayor a la cantidad de unidades en stock.");
                    else
                    {
                        // verificamos si el producto ya existe en el carrito.
                        var productExist = _carritoService.GetProduct(GetNumber(productId));
                        if (productExist == null)
                        {
                            // Si no existe en el carrrito se crea un nuevo producto
                            var productAux = new Product(product.Id, product.Name, product.Price, product.Description, product.Brand, product.Sku);
                            productAux.SetStock(cantidad);
                            // Se agrega el producto al carrito.
                            _carritoService.AddProduct(productAux);
                        }
                        else
                        {
                            // Si ya existe en el carrito se modifica el stock de ese producto en la lista.
                            var productAux = new Product(product.Id, product.Name, product.Price, product.Description, product.Brand, product.Sku);
                            productAux.SetStock(productExist.Stock + cantidad);
                            _carritoService.UpdateProduct(productExist, productAux);
                        }
                        // Se modifica el stock del producto que se compro en la lista de productos a la venta.
                        var index = ActualProducts.FindIndex(p => p.Id == product.Id);
                        TestData.ProductList.ElementAt(index).SetStock(product.Stock - cantidad);
                    }
                }
                Console.WriteLine("¿Desea comprar más productos? (S/N)");
                exit = Console.ReadLine().ToUpper() == "S" ? true : false;
            }
            Console.WriteLine("Se han agregado los productos al carrito correctamente.");
            Console.WriteLine("Presione cualquier tecla para continuar");
            Console.ReadLine();
        }
        private void ConsultarCarrito()
        {
            Console.Clear();
            if(_carritoService.GetProducts().Count == 0)
                Console.WriteLine("No hay productos en el carrito.");
            else
            {
                Console.WriteLine("Los productos que hay en el carrito son:\n");
                Console.WriteLine($"Nombre\tCantidad\tPrecio\tCosto");
                foreach (var p in _carritoService.GetProducts())
                {
                    Console.WriteLine($"{p.Name}\t{p.Stock}\t\t{p.Price}\t{p.Price*p.Stock}");
                }
                Console.WriteLine($"\nEl total hasta el momento es de { _carritoService.GetProducts().Sum(p => p.Price * p.Stock)}\n");
            }
            Console.WriteLine($"Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void HacerPedido()
        {
            Console.Clear();
            // Verificamos si el carrito cuenta con productos
            if (_carritoService.GetProducts().Count == 0)
                Console.WriteLine("No hay productos en el carrito actualmente.");
            else
            {
                ConsultarCarrito();
                Console.WriteLine("¿Desea hacer el pedido de estos productos? (S/N)");
                if(Console.ReadLine().ToUpper() == "S")
                {
                    var products = new List<Product>();
                    foreach(var p in _carritoService.GetProducts())
                        products.Add(p);
                    var clientOrder = new ClientOrder(products);
                    _clientOrderService.AddClientOrder(clientOrder);
                    _carritoService.EmptyCarrito();
                    Console.WriteLine("Se ha hecho el pedido correctamente.");
                }
                else
                {
                    Console.WriteLine("No se ha hecho el pedido.");
                }
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void ConsultarPedido()
        {
            Console.Clear();
            if (_clientOrderService.GetClientOrders().Count == 0)
                Console.WriteLine("No hay pedidos aun.");
            else
            {
                Console.WriteLine("Su pedidos son las siguientes:");
                foreach (var orden in _clientOrderService.GetClientOrders())
                {
                    Console.WriteLine(orden.ToString());
                    Console.WriteLine("--------------------------------------");
                }
            }
            Console.WriteLine($"Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void ReporteTotalGastado()
        {
            Console.Clear();
            if (_clientOrderService.GetClientOrders().Count == 0)
                Console.WriteLine("No hay pedidos aun.");
            else
            {
                var total = _clientOrderService.GetClientOrders().Sum(order => order.Total);
                Console.WriteLine($"El total gastado por todos los pedidos es de {total}");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }
}
