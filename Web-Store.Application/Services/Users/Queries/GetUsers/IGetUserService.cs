﻿namespace Web_Store.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUserService
    {
        ResultGetUserDto Execute(RequestGetUserDto request);
    }
}
