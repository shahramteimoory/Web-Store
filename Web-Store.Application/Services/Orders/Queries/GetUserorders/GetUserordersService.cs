using Microsoft.EntityFrameworkCore;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Orders.Queries.GetUserorders
{
    public class GetUserordersService : IGetUserordersService
    {
        private readonly IDataBaseContext _context;
        public GetUserordersService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<GetUserOrderDto>> Execute(long UserId)
        {
            //paginashen am bayad bezaram
            var order = _context.order.Where(o => o.UserId == UserId)
                .Include(o => o.RequestPay)
                .Include(o => o.orderDetails)
                .ThenInclude(o => o.Product)
                .OrderByDescending(o => o.UserId).Select(o => new GetUserOrderDto
                {
                    OrderId = o.Id,
                    OrderState = o.OrderState,
                    RequestPayId = o.RequestPayId,
                    Address = o.RequestPay.Address,
                    Mobile = o.RequestPay.Mobile,
                    NationalCode = o.RequestPay.NationalCode,
                    orderDetail = o.orderDetails.Select(p => new OrderDetailDto
                    {
                        Count = p.Count,
                        OrderDetailId = p.Id,
                        Price = p.Price,
                        ProductId = p.ProductId,
                        ProductName = p.Product.Name,
                        ProductSrc = p.Product.ProductImages.FirstOrDefault().Src

                    }).ToList(),
                }).ToList();
            return new ResultDto<List<GetUserOrderDto>>()
            {
                Data = order,
                IsSuccess = true,
            };

        }
    }
}
