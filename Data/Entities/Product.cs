using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set; }
        public string Sku { get; private set; }
        public string Description { get; private set; }
        public string Brand { get; private set; }
        public Subdepartment Subdepartment { get; private set; }

        public Product(int id, string name, decimal price, string description, string brand, string sku, int stock = 1)
        {
            if (price < 0)
                throw new InvalidOperationException("El precio no puede ser menor a cero.");

            if (stock <= 0)
                throw new InvalidOperationException("El stock tiene que ser mayor a cero");

            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacio");

            if (string.IsNullOrEmpty(description))
                throw new ArgumentNullException("La descripcion no puede ser vacia");

            if (string.IsNullOrEmpty(brand))
                throw new ArgumentNullException("La marca no puede ser vacia");

            if (string.IsNullOrEmpty(sku))
                throw new ArgumentNullException("El SKU no puede ser vacio");

            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Brand = brand;
            Sku = sku;
            Stock = stock;
        }

        public void AddSubdepartment(Subdepartment subdepartment)
        {
            if (subdepartment == null)
                throw new ArgumentNullException("Se requiere un subdepartamento");

            Subdepartment = subdepartment;
        }
        
        public void Update(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public void SetStock(int stock)
        {
            Stock = stock;
        }

        public override string ToString()
        {
            return $"{Id} \t {Name} \t {Brand} \t {Sku} \t {Stock} \t {Description} \t {Subdepartment?.Name} \t{Subdepartment?.Department?.Name}";
        }
    }
}
