using DoloniToys.Domain.Identity;
using DoloniToys.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;

        public AccountRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetAuthorizedAsync(string email)
        {
            User findAuthorize = await _userManager.FindByEmailAsync(email);
            if (findAuthorize is not null)
            {
                return findAuthorize;
            }
            return null;
        }

        public async Task<IdentityResult> UpdateDevUserAsync(User updator)
        {
            if (updator is not null)
            {
                User findUpdator = await _userManager.FindByNameAsync(updator.UserName);
                if (findUpdator is not null)
                {
                    return await _userManager.UpdateAsync(findUpdator);
                }
            }
            return null;
        }
    }
}
