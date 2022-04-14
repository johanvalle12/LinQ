using Business.Services.Abstractions;
using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ReportService : IReportService
    {
        private List<Product> ProductList = TestData.ProductList;

        private List<PurchaseOrder> PurchaseOrderList = new PurchaseOrderService().GetPurchaseOrders();
        public List<ProductReportDto> Top5ProductosMasCaros()
        {
            return ProductList
                .OrderByDescending(c => c.Price)
                .Take(5)
                .Select(c => new ProductReportDto
                {
                    Name = c.Name,
                    Price = c.Price
                }).ToList();
        }

        public List<ProductReportUnitStockDto> Productos5UnidadesOMenos()
        {
            return ProductList
                .Where(c => c.Stock <= 5)
                .OrderBy(c => c.Stock)
                .Select(c => new ProductReportUnitStockDto
                {
                    Name = c.Name,
                    Stock = c.Stock
                }).ToList();
        }
        public List<ProductReportBrandDto> ProductosPorMarca()
        {
            return ProductList
                .OrderBy(c => c.Name)
                .GroupBy(c => c.Brand)
                .OrderBy(c => c.Key)
                .Select(c => new ProductReportBrandDto
                {
                    Brand = c.Key,
                    Products = c.ToList()
                }).ToList();
        }
        public void DepartamentoSubdepartamentosProductos()
        {
            //return;
        }

        public List<PurchaseOrderReportPaidLast7DaysDto> OrdenesDeCompraPagadasUltimos7dias()
        {
            return PurchaseOrderList.FindAll(order => order.PurchaseDate >= DateTime.Today.AddDays(-7))
                .Select(s => new PurchaseOrderReportPaidLast7DaysDto
                {
                    Id = s.Id
                }).ToList();
        }

        public List<PurchaseOrderReportDto> OrdenDeCompraAbastecio()
        {
            return PurchaseOrderList.Where(order => order.PurchasedProducts.Any(product => product.Name.Equals("Silla")))
                .Select(s => new PurchaseOrderReportDto
                {
                    Id = s.Id,
                    Name = "Silla",
                    Quantity = 5
                })
                .ToList();
        }

        //public List<PurchaseOrderReportDto> OrdenDeCompraPendientesPorPagarXProveedor()
        //{
        //    return;
        //}

        public Product ProductoMasComprado()
        {
            return PurchaseOrderList.Where(c => c.Status == Data.Enums.PurchaseOrderStatus.Paid)
                .SelectMany(c => c.PurchasedProducts)
                .GroupBy(c => c.Id)
                .Select(c => new { Product = c.First(), Sum = c.Sum(d => d.Stock) })
                .OrderByDescending(c => c.Sum)
                .FirstOrDefault()?
                .Product;
        }
    }
}
