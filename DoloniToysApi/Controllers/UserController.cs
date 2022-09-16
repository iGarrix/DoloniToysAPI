using DoloniToys.Domain.Dtos.Identity;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.RequestModels.Identity;
using DoloniToys.Domain.Resources;
using DoloniToys.Domain.ResponseModel.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoloniToysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public UserController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet(AccountPaths.GetAuthorize)]
        [Authorize]
        public async Task<UserDto> GetAuthorizate()
        {
            UserDto response = await _accountService.GetAuthorizeAsync(User.Claims.FirstOrDefault().Value);
            return response;
        }

        [HttpPost(AccountPaths.LogInAuthorize)]
        public async Task<AuthorizateResponse> LogIn([FromBody] LogInRequest logInRequest)
        {
            AuthorizateResponse authorizateResponse = await _accountService.LogInAsync(logInRequest);
            return authorizateResponse;
        }

        [HttpPost(AccountPaths.RefreshTokenAuthorize)]
        public async Task<AuthorizateResponse> RefreshToken([FromBody] RefreshAuthorizateRequest refreshAuthorizateRequest)
        {
            AuthorizateResponse authorizateResponse = await _accountService.RefreshTokenAsync(refreshAuthorizateRequest);
            return authorizateResponse;
        }
    }
}
