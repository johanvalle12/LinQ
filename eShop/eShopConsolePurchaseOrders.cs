using Business.Services;
using Data.Entities;
using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        //private static List<PurchaseOrder> OrdenesDeCompra = new List<PurchaseOrder>();
        private void MenuOrdenDeCompra()
        {
            Console.Clear();
            Console.WriteLine("Menu Ordenes de Compra.");
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1.- Hacer una compra.");
            Console.WriteLine("2.- Mostrar ordenes de compra.");
            Console.WriteLine("3.- Cambiar estatus de orden de compra.");
            Console.WriteLine("4.- Reportes.");
            Console.WriteLine("5.- Regresar.");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        AgregarOrdenDeCompra();
                        break;
                    }
                case "2":
                    {
                        ImprimirOrdenesDeCompra();
                        break;
                    }
                case "3":
                    {
                        CambiarEstatusOrdenCompra();
                        break;
                    }
                case "4":
                    {
                        MenuReportesOrdenesDeCompra();
                        break;
                    }
                default:
                    return;
            }
        }

        private void AgregarOrdenDeCompra()
        {
            var provider = SolicitarProveedor();
            List<Product> BuyingProducts = AgregandoProductos();
            PurchaseOrder Compra = new PurchaseOrder(provider, BuyingProducts);
            _purchaseOrderService.AddPurchaseOrder(Compra);
            Console.WriteLine("Se ha agregado la orden de compra correctamente.");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private Provider SolicitarProveedor()
        {
            Console.Clear();
            Console.WriteLine("Elija el proveedor:");
            // Mostrar los proveedores.
            var providers = TestData.GetProviders();
            foreach (var p in providers)
            {
                Console.WriteLine($"{p.Id}.- {p.Name}");
            }
            // Elegir un proveedor.
            var providerId = Console.ReadLine();
            var provider = _providerService.GetProvider(GetNumber(providerId));
            return provider;
        }

        private List<Product> AgregandoProductos()
        {
            List<Product> BuyingProducts = new List<Product>();
            List<Product> ActualProducts = TestData.ProductList;
            var exit = true;
            while (exit)
            {
                Console.Clear();
                Console.WriteLine("Elija un producto:");
                // Mostrar los productos
                foreach (var p in ActualProducts)
                {
                    Console.WriteLine($"{p.Id}.- {p.Name} - Costo: {p.Price} - {p.Stock} unidades");
                }
                // Elegir un producto.
                var productId = Console.ReadLine();
                var product = _productService.GetProduct(GetNumber(productId));

                var productAux = new Product(product.Id, product.Name, product.Price, product.Description, product.Brand, product.Sku);
                Console.WriteLine($"Cuantas unidades de {product.Name} desea comprar:");
                var cantidad = Console.ReadLine();
                productAux.SetStock(GetNumber(cantidad));

                BuyingProducts.Add(productAux);
                Console.WriteLine("¿Desea comprar más productos? (S/N)");
                exit = Console.ReadLine().ToUpper() == "S" ? true : false;
            }
            return BuyingProducts;
        }

        private void ImprimirOrdenesDeCompra()
        {
            Console.WriteLine("Su ordenes de compra son las siguientes:");
            foreach(var compra in _purchaseOrderService.GetPurchaseOrders())
            {
                Console.WriteLine(compra.ToString());
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine($"Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void CambiarEstatusOrdenCompra()
        {
            Console.WriteLine("¿A qué orden quieres cambiarle el estatus?");
            var poId = GetNumber(Console.ReadLine());

            Console.WriteLine("¿A qué estatus quieres cambiarlo?");
            foreach(var status in Enum.GetNames<PurchaseOrderStatus>())
            {
                Console.WriteLine(status);
            }
            var statusAux = Console.ReadLine();
            var didParse = Enum.TryParse(statusAux, out PurchaseOrderStatus newStatus);
            if (didParse)
            {
                var po = _purchaseOrderService.ChangeStatus(poId, newStatus);
                // Actualizar el stock de los productos originales que fueron comprados por la orden de compra que haya sido pagada.
                if(po.Status == PurchaseOrderStatus.Paid)
                {
                    foreach(var p in po.PurchasedProducts)
                    {
                        var product = _productService.GetProducts().Find(c => c.Id == p.Id);
                        var productAux = new Product(product.Id, product.Name, product.Price, product.Description, product.Brand, product.Sku, product.Stock);
                        productAux.SetStock(productAux.Stock + p.Stock);
                        _productService.UpdateProduct(product, productAux);
                    }
                }
                Console.WriteLine("Orden de compra actualizada correctamente.");
            }
            else
            {
                Console.WriteLine("El estatus solicitado no existe.");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }
}
