using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Carts;

namespace Web_Store.Application.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly IDataBaseContext _context;
        public CartService(IDataBaseContext context)
        {
            _context=context;
        }

        public ResultDto Add(long CartItemId)
        {
            var cartitem = _context.cartItems.Find(CartItemId);
            cartitem.Count++;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
            };
        }

        public ResultDto AddToCart(int count, long ProductId, Guid BroserId)
        {
            //چک میکنیم اگه سبد خرید وجود داشت  به سبد قبلی اضافه شه
            var cart=_context.carts.Where(c=>c.BrowserId==BroserId && c.Finished==false).FirstOrDefault();
            if (cart == null)
            {
                Cart newCart = new Cart()
                {
                    Finished = false,
                    BrowserId=BroserId,

                };
                _context.carts.Add(newCart);
                _context.SaveChanges();
                cart = newCart;

            }
            var product = _context.products.Find(ProductId);
            if (product.Inventory<=0)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message=$"موجود نیست{product.Name} محصول"
                };
            }
            
            //باید یک کارت ایتم برای کارتمون ایجاد کنیم و بش اضافه کنیم اول چک میکنیم 
            var cartitem=_context.cartItems.Where(c=>c.ProductId==ProductId && c.CartId==cart.Id).FirstOrDefault();
            if (cartitem!=null)
            {
                //این باعث میشه وقتی یه محصول رو تو سبد داره باز کلیک میکنه به مقدار اون محصول اضافه شه
                cartitem.Count++;
                _context.SaveChanges();
            }
            else
            {
                CartItems newcartItem = new CartItems()
                {
                    Cart= cart,
                    Count= count,
                    Price=product.Price,
                    Product=product,
                    

                };
                _context.cartItems.Add(newcartItem);
                _context.SaveChanges();
            }
            return new ResultDto
            {
                IsSuccess = true,
                Message=$" محصول { product.Name } با موفقیت به سبد شما اضافه شد "
            };
        }

        public ResultDto<CartDto> GetMyCart(Guid BroserId)
        {
            var cart=_context.carts.Include(c=>c.cartItems)
                .ThenInclude(c=>c.Product)
                .ThenInclude(c=>c.ProductImages)
                .Where(c=>c.BrowserId==BroserId && c.Finished==false)
                .OrderByDescending(c=>c.Id).FirstOrDefault();
            return new ResultDto<CartDto>()
            {
                Data = new CartDto
                {
                    cartItems = cart.cartItems.Select(c => new CartItemDto
                    {
                        Count = c.Count,
                        Price = c.Price,
                        Product=c.Product.Name,
                        Id=c.Id,
                        Image=c.Product.ProductImages.FirstOrDefault().Src,
                        
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }

        public ResultDto LowOff(long CartItemId)
        {
            var cartitem = _context.cartItems.Find(CartItemId);
            if (cartitem.Count == 1) 
            {
                return new ResultDto()
                {
                    IsSuccess = false
                };
            }
            cartitem.Count--;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
            };
        }

        public ResultDto RemoveFromCart(long ProductId, Guid BroserId)
        {
            var cartitem=_context.cartItems.Where(ci=>ci.Cart.BrowserId==BroserId).FirstOrDefault();
            if (cartitem!=null)
            {
                cartitem.IsRemoved = true;
                cartitem.RemoveTime = DateTime.Now;
                _context.SaveChanges();
                return new ResultDto
                {
                    IsSuccess = true,
                    Message = "محصول از سبد خرید شما حذف شد"
                };
            }
            else
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "محصول در سبد خرید شما یافت نشد"
                };
            }
        }
    }
}
