using System.Collections.Generic;
using Web_Store.Domain.Entites.Orders;

namespace Web_Store.Application.Services.Orders.Queries.GetUserorders
{
    public class GetUserOrderDto
    {
        public long OrderId { get; set; }
        public long RequestPayId { get; set; }
        public OrderState OrderState { get; set; }
        public List<OrderDetailDto> orderDetail { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public long NationalCode { get; set; }
    }
}
