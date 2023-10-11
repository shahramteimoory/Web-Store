using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Services.Finances.Commands.AddRequestPay;
using Web_Store.Application.Services.Finances.Queries.GetRequestPay;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface IFinancesFacad
    {
        IAddRequestPayService AddRequestPayService { get; }
        IGetRequestPayService getRequestPayService { get; }
    }
}
