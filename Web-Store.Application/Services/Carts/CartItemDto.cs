namespace Web_Store.Application.Services.Carts
{
    public class CartItemDto
    {
        public long Id { get; set; }
        public string Image { get; set; }
        public string Product { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public long ProductId { get; set; }
    }
}
