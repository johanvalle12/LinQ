using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstractions
{
    public interface ICarritoService
    {
        public List<Product> GetProducts();
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void UpdateProduct(Product productOld, Product productNew);
        public void DeleteProduct(int id);
        public void EmptyCarrito();
    }
}
