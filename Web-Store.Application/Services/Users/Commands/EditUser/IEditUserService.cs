using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Users.Commands.EditUser
{
    public interface IEditUserService
    {
        public ResultDto Execute(RequestEdituserDto request);
    }
}
