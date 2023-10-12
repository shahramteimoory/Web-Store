using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Orders;

namespace Web_Store.Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState);
    }
    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersForAdminService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState)
        {
            var orders=_context.order.Include(o=>o.orderDetails)
                .Where(o=>o.OrderState == orderState)
                .OrderByDescending(o=>o.Id).Select(o=> new OrdersDto
                {
                    OrderId=o.Id,
                    InserTime=o.InsertTime,
                    RequestId=o.RequestPayId,
                    UserId=o.UserId,
                    OrderState=orderState,
                    ProductCount=o.orderDetails.Count

                }).ToList();
            return new ResultDto<List<OrdersDto>>()
            {
                Data = orders,
                IsSuccess = true
            };
        }
    }

    public class OrdersDto
    {
        public long OrderId { get; set; }
        public DateTime InserTime { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }
    }
}
