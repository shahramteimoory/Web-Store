using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RequestPayController : Controller
    {
        private readonly IFinancesFacad _financesFacad;
        public RequestPayController(IFinancesFacad financesFacad)
        {
            _financesFacad= financesFacad;
        }
        public IActionResult Index()
        {
            return View(_financesFacad.getRequestPayForAdminService.Execute().Data);
        }
    }
}
