using Business.Services.Abstractions;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class ProductService : IProductService
    {
        private List<Product> ProductList = TestData.ProductList;

        public void AddProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("El producto no puede ser nulo.");
            ProductList.Add(product);
        }

        public void DeleteProduct(int id)
        {
            var productToDelete = ProductList.FirstOrDefault(product => product.Id == id);
            if (productToDelete == null)
                throw new InvalidOperationException($"No se ha encontrado un producto con el id {id}");

            ProductList.Remove(productToDelete);
        }

        public Product GetProduct(int id)
        {
            var product = ProductList.FirstOrDefault(product => product.Id == id);
            if (product == null)
                throw new InvalidOperationException($"No se ha encontrado un producto con el id {id}");

            return product;
        }

        public List<Product> GetProducts()
        {
            return ProductList;
        }

        public void UpdateProduct(Product productOld, Product productNew)
        {
            var index = ProductList.IndexOf(productOld);
            if (index == -1)
                throw new InvalidOperationException("El producto a modificar no fue encontrado");

            ProductList[index] = productNew;
        }
    }
}
