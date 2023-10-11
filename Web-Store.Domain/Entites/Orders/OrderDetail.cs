using Web_Store.Domain.Entites.Commons;
using Web_Store.Domain.Entites.Products;

namespace Web_Store.Domain.Entites.Orders
{
    public class OrderDetail : BaseEntites
    {
        public virtual Order Order { get; set; }
        public long OrderId { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
