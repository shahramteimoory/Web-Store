namespace Web_Store.Application.Services.Orders.Queries.GetUserorders
{
    public class OrderDetailDto
    {
        public long OrderDetailId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductSrc { get; set; }

    }
}
