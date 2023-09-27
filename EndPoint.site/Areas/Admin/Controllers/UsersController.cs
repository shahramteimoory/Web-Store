using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Store.Application.Users.Commands.RegisterUser;
using Web_Store.Application.Users.Queries.GetRoles;
using Web_Store.Application.Users.Queries.GetUsers;

namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    { 
        private readonly IGetUserService _getUserService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        public UsersController(IGetUserService getUserService
            , IGetRolesService getRolesService
            , IRegisterUserService registerUserService)
        {
                _getUserService = getUserService;
                _getRolesService = getRolesService;
                _registerUserService = registerUserService;
        }

        
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

        [HttpPost]
        public IActionResult Create(string Email,string FullName ,long RoleId , string Password , string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesInRegisterUserServiceDto>()
                {
                    new RolesInRegisterUserServiceDto()
                    {
                        Id = RoleId,
                    }
                },
                Password = Password,
                RePasword = RePassword
            }) ;
            return Json(result);
        }
    }
}
