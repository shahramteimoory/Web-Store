using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Domain.Entites.Orders;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrdersController : Controller
    {
        private readonly IOrdersFacad _ordersFacad;
        public OrdersController(IOrdersFacad ordersFacad)
        {
            _ordersFacad=ordersFacad;
        }
        public IActionResult Index(OrderState orderState)
        {

            return View(_ordersFacad.getOrdersForAdminService.Execute(orderState).Data);
        }
    }
}
