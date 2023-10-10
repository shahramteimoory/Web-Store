using EndPoint.site.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
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
           var userId=ClaimUtilities.GetUserId(User);

          var result=_cartService.GetMyCart(_cookieManager.GetBrowserId(HttpContext), userId);
            return View(result.Data);
        }
        [HttpPost]
        public IActionResult AddToCart(long prductId,int count)
        {
          var res=_cartService.AddToCart(count, prductId, _cookieManager.GetBrowserId(HttpContext));
            return Json(res);
        }

        public IActionResult Add(long CartItemId)
        {
            var userId = ClaimUtilities.GetUserId(User);
            Guid browserId = _cookieManager.GetBrowserId(HttpContext);
                var userCart = _cartService.GetMyCart(browserId, userId).Data;

                foreach (var cartItem in userCart.cartItems)
                {
                    if (CartItemId == cartItem.Id)
                    {
                    _cartService.Add(CartItemId);
                    return RedirectToAction("Index");
                    }
                }
                return RedirectToAction("Index");
          
        }
        public IActionResult LowOff(long CartItemId)
        {
            var userId = ClaimUtilities.GetUserId(User);
            Guid browserId = _cookieManager.GetBrowserId(HttpContext);
            var userCart = _cartService.GetMyCart(browserId, userId).Data;

            foreach (var cartItem in userCart.cartItems)
            {
                if (CartItemId == cartItem.Id)
                {
                    _cartService.LowOff(CartItemId);
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Remove(long ProductId)
        {
            _cartService.RemoveFromCart(ProductId, _cookieManager.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }
    }
}
