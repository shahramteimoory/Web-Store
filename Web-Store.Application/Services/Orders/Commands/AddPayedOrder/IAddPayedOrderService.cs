using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Orders;

namespace Web_Store.Application.Services.Orders.Commands.AddPayedOrder
{
    public interface IAddPayedOrderService
    {
        ResultDto Execute(AddPayedOrderServiceDto request);
    }
    public class AddPayedOrderService : IAddPayedOrderService
    {
        private readonly IDataBaseContext _context;
        public AddPayedOrderService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto Execute(AddPayedOrderServiceDto request)
        {
            var user=_context.users.Find(request.UserId);
            var requestpay=_context.requestPays.Find(request.RequestPayId);
            var cart=_context.carts.Include(c=>c.cartItems)
                .ThenInclude(c => c.Product)
                .Where(c=>c.Id==request.CartId).FirstOrDefault();
            requestpay.IsPay = true;
            requestpay.PayDate = DateTime.Now;
            requestpay.RefId = request.RefId;
            requestpay.Authority=request.Authority;

            cart.Finished = true;
            Order order = new Order()
            {
                OrderState = OrderState.Processing,
                RequestPay = requestpay,
                User = user,
            };
            _context.order.Add(order);

            List<OrderDetail>orderDetails = new List<OrderDetail>();
            foreach (var item in cart.cartItems)
            {
                //این 100% غلطه چون بعد پرداحت داریم تازه قیمت رو دوباره میگیریم 
                OrderDetail orderDetail = new OrderDetail
                {
                    Count = item.Count,
                    Order = order,
                    Price = item.Product.Price,
                    Product = item.Product,

                };
                orderDetails.Add(orderDetail);
            }
            _context.orderDetails.AddRange(orderDetails);
            _context.SaveChanges();
            return new ResultDto()
            {
                IsSuccess = true,
            };
        }
    }

    public class AddPayedOrderServiceDto
    {
        public long CartId { get; set; }
        public long RequestPayId { get; set; }
        public long UserId { get; set; }
        public long RefId { get; set; }
        public string Authority { get; set; }
    }
}
