using DotnetWorkshop.Core.DTOs;
using DotnetWorkshop.Service.Authorization.Abstract;
using DotnetWorkshop.Service.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Service.Authorization.Concrete
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly AppSettings _appSettings;
        public JwtAuthenticationManager(AppSettings appSettings) 
        {
            _appSettings = appSettings;
        }
        public AuthResponseDto Authentication(string username, string password)
        {
            AuthResponseDto authResponse = new AuthResponseDto();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var tokenDescripter = new SecurityTokenDescriptor
                {
                    Expires = DateTime.UtcNow.AddHours(1),
                    Subject = new System.Security.Claims.ClaimsIdentity(
                        new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescripter);
                authResponse.Token = tokenHandler.WriteToken(token);

                return authResponse;
            }
            catch (Exception)
            {

                return authResponse;
            }
        }

        public int? ValidateJwtToken(string jwtToken)
        {
            throw new NotImplementedException();
        }
    }
}
