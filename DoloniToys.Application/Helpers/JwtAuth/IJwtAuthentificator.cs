using DoloniToys.Domain.Identity;
using DoloniToys.Domain.ResponseModel.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Helpers.JwtAuth
{
    public interface IJwtAuthentificator
    {
        AuthorizateResponse CreateToken(DevUser user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
