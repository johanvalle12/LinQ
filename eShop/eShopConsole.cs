using Business.Services.Abstractions;
using Business.Services.Implementations;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop
{
    public partial class eShopConsole
    {
        private readonly IProductService _productService;
        private readonly IDepartmentService _departmentService;
        private readonly IReportService _reportService;
        private readonly IPurchaseOrderService _purchaseOrderService;
        private readonly IProviderService _providerService;
        private readonly ICarritoService _carritoService;
        private readonly IClientOrderService _clientOrderService;

        public eShopConsole()
        {
            _productService = new ProductService();
            _departmentService = new DepartmentService();
            _reportService = new ReportService();
            _purchaseOrderService = new PurchaseOrderService();
            _providerService = new ProviderService();
            _carritoService = new CarritoService();
            _clientOrderService = new ClientOrderService();
        }
        public bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al sistema.");
            Console.WriteLine("Elija una opcion");
            Console.WriteLine("1.- Menu de Administrador.");
            Console.WriteLine("2.- Menu de Cliente.");
            Console.WriteLine("3.- Salir del sistema.");

            switch (Console.ReadLine())
            {
                case "1":
                    {
                        AdminMenu();
                        break;
                    }
                case "2":
                    {
                        ClientMenu();
                        break;
                    }
                default:
                    return false;
            }
            return true;
        }
    }
}
