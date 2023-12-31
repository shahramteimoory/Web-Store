﻿using Web_Store.Application.Services.Orders.Commands.AddPayedOrder;
using Web_Store.Application.Services.Orders.Queries.GetOrdersForAdmin;
using Web_Store.Application.Services.Orders.Queries.GetUserorders;

namespace Web_Store.Application.Interfaces.FacadPatterns
{
    public interface IOrdersFacad
    {
        IAddPayedOrderService AddPayedOrderService { get; }
        IGetUserordersService getUserordersService { get; }
        IGetOrdersForAdminService getOrdersForAdminService { get; }
    }
}
