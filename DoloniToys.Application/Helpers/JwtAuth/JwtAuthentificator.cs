using AutoMapper;
using DoloniToys.Application.Extensions.Identity;
using DoloniToys.Domain.Dtos.Identity;
using DoloniToys.Domain.Identity;
using DoloniToys.Domain.ResponseModel.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Helpers.JwtAuth
{
    public class JwtAuthentificator : IJwtAuthentificator
    {
        private readonly IMapper _mapper;
        private IConfiguration _configuration;

        public JwtAuthentificator(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }
        public AuthorizateResponse CreateToken(User user)
        {
            if (user is not null)
            {
                List<Claim> claims = new List<Claim>()
                {
                    new Claim("username", user.UserName),
                };

                JwtSecurityToken jwtprivate = this.GenerateSecurityToken(claims);
                string refreshToken = this.GenerateRefreshToken();
                return new AuthorizateResponse
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtprivate),
                    RefreshToken = refreshToken,
                    Profile = user.ToDto<User, DevUserDto>(_mapper),
                };
            }
            return null;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("JwtKey"))),
                ValidateLifetime = false,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        private JwtSecurityToken GenerateSecurityToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<String>("JwtKey")));
            _ = int.TryParse(_configuration.GetValue<String>("TokenValidityInHour"), out int TokenValidityInHour);
            DateTime expiredIn = DateTime.Now.AddHours(TokenValidityInHour);
            var token = new JwtSecurityToken(
                expires: expiredIn,
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
