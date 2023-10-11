using System;

namespace Web_Store.Application.Services.Finances.Commands.AddRequestPay
{
    public class ResultRequestPayDto
    {
        public Guid Guid { get; set; }
        public int Amount { get; set; }
        public string Email { get; set; }
        public long RequestPayId { get; set; }
    }
}
