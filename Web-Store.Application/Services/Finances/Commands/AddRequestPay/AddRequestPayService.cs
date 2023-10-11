using System;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;
using Web_Store.Domain.Entites.Finances;

namespace Web_Store.Application.Services.Finances.Commands.AddRequestPay
{
    public class AddRequestPayService : IAddRequestPayService
    {
        private readonly IDataBaseContext _context;
        public AddRequestPayService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<ResultRequestPayDto> Execute(int amount, long UserId)
        {
            var user = _context.users.Find(UserId);
            RequestPay requestPay = new RequestPay()
            {
                Amount = amount,
                UserId = UserId,
                Guid = Guid.NewGuid(),
                IsPay=false,
                User= user,
            };
            _context.requestPays.Add(requestPay);
            _context.SaveChanges();
            return new ResultDto<ResultRequestPayDto>()
            {
                Data = new ResultRequestPayDto()
                {
                    Guid = requestPay.Guid,
                    Amount=requestPay.Amount,
                    Email=user.Email,
                    RequestPayId=requestPay.Id
                },
                IsSuccess = true,
                Message = "درخواست پرداخت ارسال شد"
            };
        }
    }
}
