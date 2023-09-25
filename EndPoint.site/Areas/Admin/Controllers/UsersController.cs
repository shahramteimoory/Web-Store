using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web_Store.Application.Users.Queries.GetRoles;
using Web_Store.Application.Users.Queries.GetUsers;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    { 
        private readonly IGetUserService _getUserService;
        private readonly IGetRolesService _getRolesService;
        public UsersController(IGetUserService getUserService, IGetRolesService getRolesService)
        {
                _getUserService = getUserService;
                _getRolesService = getRolesService;
        }

        [Area("Admin")]
        public IActionResult Index(string searchkey,int page=1)
        {
            return View(_getUserService.Execute(new RequestGetUserDto
            {
                Page = page,
                SearchKey = searchkey
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles=new SelectList(_getRolesService.Execute().Data,"Id","Name");
            return View();
        }
    }
}
