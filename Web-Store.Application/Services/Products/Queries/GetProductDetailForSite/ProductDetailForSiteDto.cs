﻿namespace Web_Store.Application.Services.Products.Queries.GetProductDetailForSite
{
    public class ProductDetailForSiteDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int price { get; set; }
        public List<string> Images { get; set; }
        public List<ProductDetailForSite_FeaturesDto> Features { get; set; }
    }
}
