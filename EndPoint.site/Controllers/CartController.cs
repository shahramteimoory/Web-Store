using EndPoint.site.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Services.Carts;

namespace EndPoint.site.Controllers
{
    public class CartController : Controller
    {
        private readonly CookiesManeger _cookieManager;
        private readonly ICartService _cartService;
        public CartController(ICartService cartService
            , CookiesManeger cookiesManeger)
        {
            _cartService= cartService;
            _cookieManager= cookiesManeger;
        }
        public IActionResult Index()
        {
          var result=_cartService.GetMyCart(_cookieManager.GetBrowserId(HttpContext));
            return View(result.Data);
        }
        [HttpPost]
        public IActionResult AddToCart(long prductId)
        {
          _cartService.AddToCart(prductId, _cookieManager.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
    }
}
