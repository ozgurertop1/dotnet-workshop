﻿using DotnetWorkshop.Core.DTOs;
using DotnetWorkshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Core.Services
{
    public interface IUserService:IService<User>
    {
        string GeneratePasswordHash(string userName, string password);
        UserDto FindUser(string userName, string password);

        AuthResponseDto Login(AuthRequestDto request);

        UserDto SignUp(AuthRequestDto request);
    }
}
