using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.ViewComponents
{
    public class GetMenuOnMobile:ViewComponent
    {
        private readonly ICommonFacad _commonFacad;
        public GetMenuOnMobile(ICommonFacad commonFacad)
        {
            _commonFacad = commonFacad;
        }

        public IViewComponentResult Invoke()
        {
            var menuitem = _commonFacad.getMenuService.Execute();
            return View(viewName: "GetMenuOnMobile", menuitem.Data);
        }
    }
}
