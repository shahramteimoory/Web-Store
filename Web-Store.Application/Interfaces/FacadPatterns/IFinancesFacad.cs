using Web_Store.Application.Services.Finances.Commands.AddRequestPay;
using Web_Store.Application.Services.Finances.Queries.GetRequestPay;
using Web_Store.Application.Services.Finances.Queries.GetRequestPayForAdmin;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface IFinancesFacad
    {
        IAddRequestPayService AddRequestPayService { get; }
        IGetRequestPayService getRequestPayService { get; }
        IGetRequestPayForAdminService getRequestPayForAdminService { get; }
    }
}
