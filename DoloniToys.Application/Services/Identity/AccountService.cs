using AutoMapper;
using DoloniToys.Application.Extensions.Identity;
using DoloniToys.Application.Helpers.JwtAuth;
using DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers;
using DoloniToys.Domain.Dtos.Identity;
using DoloniToys.Domain.Identity;
using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.RequestModels.Identity;
using DoloniToys.Domain.ResponseModel.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IJwtAuthentificator _jwtAuthentificator;
        private readonly UserManager<DevUser> _devManager;

        public AccountService(IRepositoryWrapper repositoryWrapper, IMapper mapper, IConfiguration configuration, IJwtAuthentificator jwtAuthentificator, UserManager<DevUser> devManager)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _configuration = configuration;
            _jwtAuthentificator = jwtAuthentificator;
            _devManager = devManager;
        }

        public async Task<DevUserDto> GetAuthorizeAsync(string username)
        {
            DevUser findAuthorize = await _repositoryWrapper.AccountRepository.GetAuthorizedAsync(username);
            if (findAuthorize is null)
            {
                throw new NotFoundHandler();
            }
            return findAuthorize.ToDto<DevUser, DevUserDto>(_mapper);
        }

        public async Task<AuthorizateResponse> LogInAsync(LogInRequest logInRequest)
        {
            DevUser logInDev = await _repositoryWrapper.AccountRepository.GetAuthorizedAsync(logInRequest.Email);
            bool passwordValid = await _devManager.CheckPasswordAsync(logInDev, logInRequest.Password);
            if (passwordValid)
            {
                if (logInDev is not null)
                {
                    AuthorizateResponse authorize_data = _jwtAuthentificator.CreateToken(logInDev);
                    if (authorize_data is not null)
                    {
                        logInDev.RefreshToken = authorize_data.RefreshToken;
                        logInDev.RefreshTokenExpiryTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).AddDays(_configuration.GetValue<Int32>("RefreshTokenValidityInDays"));
                        IdentityResult updateResult = await _repositoryWrapper.AccountRepository.UpdateDevUserAsync(logInDev);
                        if (updateResult.Succeeded)
                        {
                            return authorize_data;
                        }
                    }
                    throw new BadHandler("Authorize data genereted failure");
                }
                throw new NotFoundHandler("Log in was failure");
            }
            throw new BadHandler("You entered incorrect password");
        }

        public async Task<AuthorizateResponse> RefreshTokenAsync(RefreshAuthorizateRequest refreshAuthorizateRequest)
        {
            if (refreshAuthorizateRequest is null)
            {
                throw new BadHandler("Request is expired");
            }

            var principal = _jwtAuthentificator.GetPrincipalFromExpiredToken(refreshAuthorizateRequest.AccessToken);
            if (principal is null)
            {
                throw new BadHandler("Invalid access token or refresh token");
            }

            string username = principal.Identities.FirstOrDefault().Claims.FirstOrDefault().Value;
            DevUser refreshDev = await _repositoryWrapper.AccountRepository.GetAuthorizedAsync(username);

            if (refreshDev is null || refreshDev.RefreshToken != refreshAuthorizateRequest.RefreshToken || refreshDev.RefreshTokenExpiryTime <= DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc))
            {
                throw new BadHandler("Invalid access token or refresh token");
            }

            AuthorizateResponse authorize_data = _jwtAuthentificator.CreateToken(refreshDev);
            if (authorize_data is not null)
            {
                refreshDev.RefreshToken = authorize_data.RefreshToken;
                refreshDev.RefreshTokenExpiryTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc).AddDays(_configuration.GetValue<Int32>("RefreshTokenValidityInDays"));
                IdentityResult updateResult = await _repositoryWrapper.AccountRepository.UpdateDevUserAsync(refreshDev);
                if (updateResult.Succeeded)
                {
                    return authorize_data;
                }
            }
            throw new BadHandler("Authorize data genereted failure");
        }
    }
}
