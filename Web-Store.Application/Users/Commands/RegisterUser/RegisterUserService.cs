using System;
using System.Collections.Generic;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Users;

namespace Web_Store.Application.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;
        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message="لطفا نام خود را وارد کنید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId= 0,
                        },
                       IsSuccess=false,
                       Message="لطفا ایمیل خود را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "لطفا رمز عبور را وارد کنید"
                    };
                }
                if (request.Password != request.RePasword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }
                User user = new User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    InsertTime = DateTime.Now,

                };
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.Roles)
                {
                    var roles = _context.roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleID = roles.Id,
                        User = user,
                        UserId = user.Id
                    });
                }
                user.UserInRoles = userInRoles;
                _context.users.Add(user);
                _context.SaveChanges();

                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام با موفقیت انجام شد"
                };
            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "( ایمیل تکراریست ) ثبت نام انجام نشد"
                };
                
            }

        }
    }
}
