using DoloniToys.Domain.Dtos.Identity;
using DoloniToys.Domain.RequestModels.Identity;
using DoloniToys.Domain.ResponseModel.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Services
{
    public interface IAccountService
    {
        Task<DevUserDto> GetAuthorizeAsync(string username);
        Task<AuthorizateResponse> LogInAsync(LogInRequest logInRequest);
        Task<AuthorizateResponse> RefreshTokenAsync(RefreshAuthorizateRequest refreshAuthorizateRequest);
    }
}
