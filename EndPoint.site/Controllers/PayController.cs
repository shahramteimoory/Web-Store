using Dto.Payment;
using EndPoint.site.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Carts;
using ZarinPal.Class;

namespace EndPoint.site.Controllers
{
    [Authorize]
    public class PayController : Controller
    {
        private readonly IFinancesFacad _finances;
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookieManager;
        private readonly Payment _payment;
        private readonly Authority _authority;
        private readonly Transactions _transactions;
        public PayController(IFinancesFacad finances
            , ICartService cartService
            , CookiesManeger cookiesManeger)
        {
            _finances=finances;
            _cartService=cartService;
            _cookieManager=cookiesManeger;
            var expose = new Expose();
            _payment = expose.CreatePayment();
            _authority = expose.CreateAuthority();
            _transactions = expose.CreateTransactions();
        }
        public async Task<IActionResult> Index()
        {
            long? userId = ClaimUtilities.GetUserId(User);
            var cart = _cartService.GetMyCart(_cookieManager.GetBrowserId(HttpContext), userId);
           
            if (cart.Data.SumAmount >0)
            {
                var requestpay = _finances.AddRequestPayService.Execute(cart.Data.SumAmount, userId.Value);


                //ارسال به درگاه پرداخت 

                string guidString = requestpay.Data.Guid.ToString(); // تبدیل GUID 
                var result = await _payment.Request(new DtoRequest()
                {
                    Mobile = "09121112222",
                    CallbackUrl = $"http://localhost:37278/Pay/Verify?guid={requestpay.Data.Guid}",
                    Description = "پرداخت شماره فاکتور:"+requestpay.Data.RequestPayId,
                    Email = requestpay.Data.Email,
                    Amount = requestpay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"
                }, ZarinPal.Class.Payment.Mode.sandbox);
                return Redirect($"https://sandbox.zarinpal.com/pg/StartPay/{result.Authority}");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        /// <summary>
        /// اعتبار سنجی خرید
        /// </summary>
        /// <param name="authority"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IActionResult> Verify(Guid guid, string authority, string status)
        {
            var requestpay = _finances.getRequestPayService.Execute(guid);
            //اگه تو حالت عملیاتی کار نکرد از این رست فول استفاده کن
            //var client = new RestClient("https://www.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            //client.Timeout = -1;
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", $"{{\"MerchantID\" :\"{merchendId}\",\"Authority\":\"{Authority}\",\"Amount\":\"{10000}\"}}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);
            //VerificationPayResultDto verification = JsonConvert.DeserializeObject<VerificationPayResultDto>(response.Content);
            var verification = await _payment.Verification(new DtoVerification
                {
                    Amount = requestpay.Data.Amount,
                    MerchantId = "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX",
                    Authority = authority
                }, Payment.Mode.sandbox);
            if (verification.Status==100)
            {

            }
            else
            {
                
            }
            return View();
            

        }
    }

}
