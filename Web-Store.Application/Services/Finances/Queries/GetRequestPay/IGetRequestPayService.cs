using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Finances.Queries.GetRequestPay
{
    public interface IGetRequestPayService
    {
        ResultDto<RequestPayDto> Execute(Guid guid);
    }
    public class GetRequestPayService : IGetRequestPayService
    {
        private readonly IDataBaseContext _context;
        public GetRequestPayService(IDataBaseContext context)
        {
            _context=context;
        }
        public ResultDto<RequestPayDto> Execute(Guid guid)
        {
            var requestpay=_context.requestPays.Where(r=>r.Guid==guid).FirstOrDefault();
            if (requestpay !=null)
            {
                return new ResultDto<RequestPayDto>()
                {
                    Data = new RequestPayDto()
                    {
                        Amount = requestpay.Amount,
                    },
                    IsSuccess = true
                };
            }
            else
            {
                return new ResultDto<RequestPayDto>
                {
                    Data = new RequestPayDto()
                    {
                        Amount = 0,
                    },
                    IsSuccess = false
                };
            }
        }
    }

    public class RequestPayDto
    {
        public int Amount { get; set; }
    }
}
