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
        private readonly IProductRepository _productRepository;
        private readonly IQuestionRepository _questionRepository;
        public RepositoryWrapper(IAccountRepository accountRepository, ICategoryRepository categoryRepository, IProductRepository productRepository, IQuestionRepository questionRepository)
        {
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _questionRepository = questionRepository;
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

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository is null)
                {
                    return null;
                }
                return _productRepository;
            }
        }

        public IQuestionRepository QuestionRepository
        {
            get
            {
                if (_questionRepository is null)
                {
                    return null;
                }
                return _questionRepository;
            }
        }
    }
}
