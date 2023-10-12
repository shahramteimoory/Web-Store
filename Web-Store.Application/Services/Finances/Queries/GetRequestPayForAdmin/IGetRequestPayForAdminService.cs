using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Common.Dto;

namespace Web_Store.Application.Services.Finances.Queries.GetRequestPayForAdmin
{
    public interface IGetRequestPayForAdminService
    {
        ResultDto<List<RequestPayDto>> Execute();
    }
    public class GetRequestPayForAdminService : IGetRequestPayForAdminService
    {
        private readonly IDataBaseContext _Context;
        public GetRequestPayForAdminService(IDataBaseContext context)
        {
            _Context = context;
        }
        public ResultDto<List<RequestPayDto>> Execute()
        {
            var requestpay = _Context.requestPays.Select(r => new RequestPayDto
            {
                Address = r.Address,
                UserId = r.UserId,
                Amount = r.Amount,
                User_Name = r.User.FullName,
                IsPay = r.IsPay,
                PayDate = r.PayDate,
                Authority = r.Authority,
                RefId = r.RefId,
                NationalCode = r.NationalCode,
                Guid = r.Guid,
                Mobile = r.Mobile,
                Id = r.Id,
            }).ToList();
            return new ResultDto<List<RequestPayDto>>()
            {
                Data = requestpay,
                IsSuccess = true
            };
        }
    }

    public class RequestPayDto
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public string User_Name { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
        public string Address { get; set; }
        public string Mobile { get; set; }
        public long NationalCode { get; set; }
    }
}
