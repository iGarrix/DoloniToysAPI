using DoloniToys.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<User> GetAuthorizedAsync(string email);
        Task<IdentityResult> UpdateDevUserAsync(User updator);
    }
}
