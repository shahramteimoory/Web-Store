using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.Products
{
    public class Product:BaseEntites
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Display { get; set; }
        public int ViewCount { get; set; }
        public virtual Category Category { get; set; }
        public long CategoryId { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; }
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }

    }
}
