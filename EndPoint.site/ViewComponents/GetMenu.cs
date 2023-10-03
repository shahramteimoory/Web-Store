using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.ViewComponents
{
    public class GetMenu:ViewComponent
    {
        private readonly ICommonFacad _commonFacad;
        public GetMenu(ICommonFacad commonFacad)
        {
            _commonFacad=commonFacad;
        }

        public IViewComponentResult Invoke()
        {
            var menuitem = _commonFacad.getMenuService.Execute();
            return View(viewName: "GetMenu", menuitem.Data);
        }
    }
}
