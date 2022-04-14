using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private void MenuReportesOrdenesDeCompra()
        {
            Console.Clear();
            Console.WriteLine("Menu Reportes de Ordenes de Compra.");
            Console.WriteLine("Elige una opcion");
            Console.WriteLine("1.- Pagadas en los ultimos 7 dias.");
            Console.WriteLine("2.- Ordenes de compra que abastecieron sillas.");
            Console.WriteLine("3.- Pendientes de pagar del proveedor Levis.");
            Console.WriteLine("4.- Producto del que se han comprado mas unidades.");
            Console.WriteLine("5.- Regresar.");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        OrdenesDeCompraPagadasUltimos7Dias();
                        break;
                    }
                case "2":
                    {
                        OrdenDeCompraAbastecioXProducto();
                        break;
                    }
                case "3":
                    {
                        PendientesDePagarXProveedor();
                        break;
                    }
                case "4":
                    {
                        ProductoMasComprado();
                        break;
                    }
                default:
                    return;
            }
        }

        private void OrdenesDeCompraPagadasUltimos7Dias()
        {
            //var result = _reportService.OrdenesDeCompraPagadasUltimos7dias();
            var result = _purchaseOrderService.GetPurchaseOrders()
                .FindAll(order => order.PurchaseDate >= DateTime.Today.AddDays(-7))
                .Where(order => order.Status == Data.Enums.PurchaseOrderStatus.Paid);

            foreach(var order in result)
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void OrdenDeCompraAbastecioXProducto()
        {
            //var result = _reportService.OrdenDeCompraAbastecio();
            var result = _purchaseOrderService.GetPurchaseOrders().Where(order => order.PurchasedProducts.Any(product => product.Name.Equals("Silla")))
                .Select(s => new { Id = s.Id, Name = "Silla", Quantity = s.PurchasedProducts.Where(product=>product.Name.Equals("Silla")).Sum(product=>product.Stock) }); ;
            foreach (var order in result)
            {
                Console.WriteLine($"La orden de compra {order.Id} abastecio {order.Quantity} {order.Name}s");
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void PendientesDePagarXProveedor()
        {
            var result = _purchaseOrderService.GetPurchaseOrders()
                .FindAll(order => order.Provider.Name.Equals("Levis"))
                .Where(order => order.Status == Data.Enums.PurchaseOrderStatus.Pending);

            foreach (var order in result)
            {
                Console.WriteLine(order.ToString());
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }

        private void ProductoMasComprado()
        {
            var result = _reportService.ProductoMasComprado();
            Console.WriteLine($"El producto mas comprado es: {result.Name}");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadLine();
        }
    }
}
