using DotnetWorkshop.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Service.Authorization.Abstract
{
    internal interface IJwtAuthenticationManager
    {
        AuthResponseDto Authentication(string username, string password);
        string ValidateJwtToken(string jwtToken);
    }
}
