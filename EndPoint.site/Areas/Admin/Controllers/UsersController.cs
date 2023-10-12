using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Web_Store.Application.Services.Users.Commands.EditUser;
using Web_Store.Application.Services.Users.Commands.RegisterUser;
using Web_Store.Application.Services.Users.Commands.RemoveUser;
using Web_Store.Application.Services.Users.Commands.UserStatusChange;
using Web_Store.Application.Services.Users.Queries.GetRoles;
using Web_Store.Application.Services.Users.Queries.GetUsers;


namespace EndPoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    { 
        private readonly IGetUserService _getUserService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _RemoveUserService;
        private readonly IUserStatusChangeService _userStatusChangeService;
        private readonly IEditUserService _editUserService;
        public UsersController(IGetUserService getUserService
            , IGetRolesService getRolesService
            , IRegisterUserService registerUserService
            , IRemoveUserService RemoveUserService
            ,IUserStatusChangeService userStatusChangeService
            , IEditUserService editUserService)
        {
                _getUserService = getUserService;
                _getRolesService = getRolesService;
                _registerUserService = registerUserService;
            _RemoveUserService = RemoveUserService;
            _userStatusChangeService= userStatusChangeService;
            _editUserService = editUserService;
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
        [HttpPost]
        public IActionResult Delete(long UserId)
        {
            return Json(_RemoveUserService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult UserStatusChange(long UserId)
        {
            return Json(_userStatusChangeService.Execute(UserId));
        }

        [HttpPost]
        public IActionResult Edit(long UserId, string FullName,string Email)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                UserId = UserId,
                Fullname = FullName,
                Email = Email
            }));
        }
    }
}
