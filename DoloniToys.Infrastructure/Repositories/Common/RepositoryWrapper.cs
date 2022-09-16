using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Infrastructure.Repositories.Common
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly IAccountRepository _accountRepository;

        public RepositoryWrapper(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IAccountRepository AccountRepository
        {
            get
            {
                if (_accountRepository is null)
                {
                    return null;
                }
                return _accountRepository;
            }
        }
    }
}
