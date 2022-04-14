using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ClientOrder
    {
        public int Id { get; private set; }
        public decimal Total { get; private set; }
        public DateTime PurchaseDate { get; private set; }
        public List<Product> PurchasedProducts { get; set; }

        public static int clientOrderSeed = 1;

        public ClientOrder(List<Product> purchasedProducts, DateTime? purchaseDate = null)
        {

            if (purchasedProducts == null || !purchasedProducts.Any())
                throw new ArgumentNullException("Se deben agregar productos a la orden de compra.");

            Id = clientOrderSeed;
            Total = purchasedProducts.Sum(c => c.Price * c.Stock);
            PurchasedProducts = purchasedProducts;
            PurchaseDate = purchaseDate ?? DateTime.Now;
            clientOrderSeed++;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Pedido: {Id}\nFecha de Compra: {PurchaseDate}\nProductos Comprados:");
            foreach (var p in PurchasedProducts)
            {
                var subtotal = p.Stock * p.Price;
                sb.Append($"\n{p.Stock} '{p.Name}' -> {subtotal}");
            }
            sb.Append($"\nEl total de su compra es {Total}");
            return sb.ToString();
        }
    }
}
