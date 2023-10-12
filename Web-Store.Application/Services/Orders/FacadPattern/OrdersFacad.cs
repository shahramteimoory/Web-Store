using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Orders.Commands.AddPayedOrder;
using Web_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Web_Store.Application.Services.Orders.Queries.GetUserorders;

namespace Web_Store.Application.Services.Orders.FacadPattern
{
    public class OrdersFacad : IOrdersFacad
    {
        private readonly IDataBaseContext _context;
        public OrdersFacad(IDataBaseContext context)
        {
            _context = context;
        }
        private IAddPayedOrderService _AddPayedOrderService;
        public IAddPayedOrderService AddPayedOrderService
        {
            get
            {
                return _AddPayedOrderService = _AddPayedOrderService ?? new AddPayedOrderService(_context);
            }
        }
        private IGetUserordersService _getUserordersService;
        public IGetUserordersService getUserordersService
        {
            get
            {
                return _getUserordersService = _getUserordersService ?? new GetUserordersService(_context);
            }
        }
        private IGetOrdersForAdminService _getOrdersForAdminService;
        public IGetOrdersForAdminService getOrdersForAdminService
        {
            get
            {
                return _getOrdersForAdminService = _getOrdersForAdminService ?? new GetOrdersForAdminService(_context);
            }
        }
    }
}
