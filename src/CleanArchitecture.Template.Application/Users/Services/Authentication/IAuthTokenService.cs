﻿using CleanArchitecture.Template.Application.Users.Commands.LoginUser.DTOs;
using CleanArchitecture.Template.Domain.Users;

namespace CleanArchitecture.Template.Application.Users.Services.Authentication
{
    public interface IAuthTokenService
    {
        LoginUserResponse GenerateToken(User user);
    }
}