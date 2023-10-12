using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Finances.Commands.AddRequestPay
{
    public interface IAddRequestPayService
    {
        ResultDto<ResultRequestPayDto> Execute(int amount, long UserId);
    }
}
