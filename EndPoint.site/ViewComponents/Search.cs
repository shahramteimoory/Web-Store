using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Interfaces.FacadPatterns;

namespace EndPoint.site.ViewComponents
{
    public class Search:ViewComponent
    {
        private readonly ICommonFacad _commonFacad;
        public Search(ICommonFacad commonFacad)
        {
            _commonFacad= commonFacad;
        }
        public IViewComponentResult Invoke()
        {
            return View(viewName:"Search", _commonFacad.getCategoryService.Execute().Data);
        }
    }
}
