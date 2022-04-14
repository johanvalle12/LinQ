using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Subdepartment
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public Department Department { get; set; }
        public List<Product> Products { get; set; }
        public Subdepartment(int id, string name)
        {
            if (id == 0)
                throw new ArgumentNullException("El id no puede ser vacio o 0");
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("El nombre no puede ser vacio");

            Id = id;
            Name = name;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
