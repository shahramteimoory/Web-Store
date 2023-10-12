using Web_Store.Domain.Entites.Commons;

namespace Web_Store.Domain.Entites.Products
{
    public class ProductImages : BaseEntites
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public string Src { get; set; }
    }
}
