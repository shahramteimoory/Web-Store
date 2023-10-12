using Web_Store.Domain.Entites.Commons;
using Web_Store.Domain.Entites.Orders;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Domain.Entites.Finances
{
    public class RequestPay : BaseEntites
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
        public string Address { get; set; }
        public string Mobile { get; set; }
        public long NationalCode { get; set; }
        public ICollection<Order> orders { get; set; }

    }
}
