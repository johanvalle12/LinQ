using Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PurchaseOrder
    {
        public int Id { get; private set; }
        public decimal Total { get; private set; }
        public DateTime PurchaseDate { get; private set; }

        public Provider Provider { get; private set; }
        public List<Product> PurchasedProducts { get; private set; }

        public PurchaseOrderStatus Status { get; private set; }

        public static int purchaseOrderSeed = 1;

        public PurchaseOrder(Provider provider, List<Product> purchasedProducts, DateTime? purchaseDate = null)
        {

            if (provider == null)
                throw new ArgumentNullException("El proveedor no puede ser vacio.");

            if (purchasedProducts == null || !purchasedProducts.Any())
                throw new ArgumentNullException("Se deben agregar productos a la orden de compra.");

            Status = PurchaseOrderStatus.Pending;
            Id = purchaseOrderSeed;
            Total = purchasedProducts.Sum(c => c.Price * c.Stock);
            Provider = provider;
            PurchasedProducts = purchasedProducts;
            PurchaseDate = purchaseDate ?? DateTime.Now;
            purchaseOrderSeed++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Orden de compra: {Id}\nEstatus: {Status}\nProveedor: {Provider.Name}\nFecha de Compra: {PurchaseDate}\nProductos Comprados:");
            foreach(var p in PurchasedProducts)
            {
                var subtotal = p.Stock * p.Price;
                sb.Append($"\n{p.Name} - {p.Stock} - {subtotal}");
            }
            sb.Append($"\nEl total de su compra es {Total}");
            return sb.ToString();
        }

        public void ChangeStatus(PurchaseOrderStatus status)
        {
            Status = status;
        }
    }
}
