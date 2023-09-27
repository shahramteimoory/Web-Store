using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Users.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto Execute(RequestEdituserDto request)
        {
            try
            {
                var user = _context.users.Find(request.UserId);
                if (user == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد"
                    };
                }

                user.FullName = request.Fullname;
                user.Email = request.Email;
                _context.SaveChanges();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "ویرایش کاربر انجام شد"
                };

            }
            catch 
            {

                return new ResultDto { IsSuccess = false, Message = "اطلاعات را برسی کنید" };
            }
        }
    }
}
