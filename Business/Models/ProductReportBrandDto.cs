using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ProductReportBrandDto
    {
        public string Brand { get; set; }
        public List<Product> Products { get; set; }
    }
}
