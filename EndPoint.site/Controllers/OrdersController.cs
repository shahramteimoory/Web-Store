using EndPoint.site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        private readonly IOrdersFacad _ordersFacad;
        public OrdersController(IOrdersFacad ordersFacad)
        {
            _ordersFacad = ordersFacad;
        }
        public IActionResult Index()
        {
            long? userId = ClaimUtilities.GetUserId(User).Value;
            return View(_ordersFacad.getUserordersService.Execute(userId.Value).Data);
        }
    }
}
