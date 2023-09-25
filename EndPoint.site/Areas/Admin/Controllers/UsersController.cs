using Microsoft.AspNetCore.Mvc;
using Web_Store.Application.Users.Queries.GetUsers;

namespace EndPoint.site.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IGetUserService _getUserService;
        public UsersController(IGetUserService getUserService)
        {
                _getUserService = getUserService;
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
    }
}
