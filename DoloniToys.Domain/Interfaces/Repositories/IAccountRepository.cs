using DoloniToys.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Repositories
{
    public interface IAccountRepository
    {
        Task<DevUser> GetAuthorizedAsync(string username);
    }
}
