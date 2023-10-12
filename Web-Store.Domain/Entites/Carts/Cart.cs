using Web_Store.Domain.Entites.Commons;
using Web_Store.Domain.Entites.Products;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Domain.Entites.Carts
{
    public class Cart : BaseEntites
    {
        public virtual User User { get; set; }
        public long? UserId { get; set; }
        public Guid BrowserId { get; set; }
        public bool Finished { get; set; }
        public ICollection<CartItems> cartItems { get; set; }
    }
    public class CartItems : BaseEntites
    {
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public virtual Cart Cart { get; set; }
        public long CartId { get; set; }
    }
}
