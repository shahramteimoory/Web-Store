using EndPoint.site.Utilities;
using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Services.Carts;

namespace EndPoint.site.ViewComponents
{
    public class Cart:ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        public Cart(ICartService cartService, CookiesManeger cookiesManeger)
        {
            _cartService= cartService;
            _cookiesManeger= cookiesManeger;
        }
        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtilities.GetUserId(HttpContext.User);
            return View(viewName: "Cart", _cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext), userId).Data);
        }
    }
}
