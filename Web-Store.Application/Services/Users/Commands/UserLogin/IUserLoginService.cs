using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Users.Commands.UserLogin
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string username, string password);
    }
}
