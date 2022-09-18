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
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryWrapper(IAccountRepository accountRepository, ICategoryRepository categoryRepository)
        {
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
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

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository is null)
                {
                    return null;
                }
                return _categoryRepository;
            }
        }
    }
}
