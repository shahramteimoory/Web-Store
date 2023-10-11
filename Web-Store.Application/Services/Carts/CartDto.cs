using System.Collections.Generic;

namespace Web_Store.Application.Services.Carts
{
    public class CartDto
    {
        public long CartId { get; set; }
        public int ProductCount { get; set; }
        public int SumAmount { get; set; }
        public List<CartItemDto> cartItems {  get; set; }
    }
}
