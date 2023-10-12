using Web_Store.Domain.Entites.Commons;
using Web_Store.Domain.Entites.Finances;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Domain.Entites.Orders
{
    public class Order : BaseEntites
    {
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public virtual RequestPay RequestPay { get; set; }
        public long RequestPayId { get; set; }
        public OrderState OrderState { get; set; }

        public ICollection<OrderDetail> orderDetails { get; set; }
    }
}
