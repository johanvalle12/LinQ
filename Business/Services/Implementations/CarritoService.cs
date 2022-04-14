using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class CarritoService : ICarritoService
    {
        private Carrito Carrito = new Carrito(new List<Product>());

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("El producto no puede ser nulo.");
            Carrito.Products.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = Carrito.Products.FirstOrDefault(product => product.Id == id);
            if (productToDelete == null)
                throw new InvalidOperationException($"No se ha encontrado un producto con el id {id}");

            Carrito.Products.Remove(productToDelete);
        }

        public Product GetProduct(int id)
        {
            var product = Carrito.Products.FirstOrDefault(p => p.Id == id);
            return product;
        }

        public List<Product> GetProducts()
        {
            return Carrito.Products;
        }

        public void UpdateProduct(Product productOld, Product productNew)
        {
            var index = Carrito.Products.IndexOf(productOld);
            if (index == -1)
                throw new InvalidOperationException("El producto a modificar no fue encontrado");

            Carrito.Products[index] = productNew;
        }


        public void EmptyCarrito()
        {
            Carrito.Products.Clear();
        }
    }
}
