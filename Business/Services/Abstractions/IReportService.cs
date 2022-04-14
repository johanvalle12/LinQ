using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface IReportService
    {
        public List<ProductReportDto> Top5ProductosMasCaros();
        public List<ProductReportUnitStockDto> Productos5UnidadesOMenos();
        public List<ProductReportBrandDto> ProductosPorMarca();
        public List<PurchaseOrderReportPaidLast7DaysDto> OrdenesDeCompraPagadasUltimos7dias();
        public List<PurchaseOrderReportDto> OrdenDeCompraAbastecio();
        //public List<PurchaseOrderReportDto> OrdenDeCompraPendientesPorPagarXProveedor();
        public Product ProductoMasComprado();
        //public List<ProductReportDto> DepartamentoSubdepartamentosProductos();

    }
}
