﻿using Web_Store.Domain.Entites.Commons;
using Web_Store.Domain.Entites.Orders;

namespace Web_Store.Domain.Entites.Products
{
    public class Product : BaseEntites
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
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
