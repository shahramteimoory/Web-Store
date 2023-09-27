using Microsoft.AspNetCore.Mvc;

namespace EndPoint.site.Controllers
{
    public class AuthenticationController : Controller
    {

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Signup(SignupViewModel request)
    }
}
