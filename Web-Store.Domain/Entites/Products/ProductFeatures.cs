using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.Products
{
    public class ProductFeatures : BaseEntites
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
