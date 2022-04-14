using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Carrito
    {
        public List<Product> Products { get; set; }

        public Carrito(List<Product> products)
        {
            Products = products;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Los productos que hay en el carrito son:");
            foreach (var p in Products)
            {
                var subtotal = p.Stock * p.Price;
                sb.Append($"\n{p.Stock} '{p.Name}' -> {subtotal}");
            }
            sb.Append($"\nEl total hasta el momento es de {Products.Sum(p => p.Price * p.Stock)}");
            return sb.ToString();
        }
    }
}
