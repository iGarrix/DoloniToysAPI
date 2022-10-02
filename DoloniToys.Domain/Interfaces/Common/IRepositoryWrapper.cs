using DoloniToys.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Common
{
    public interface IRepositoryWrapper
    {
        IAccountRepository AccountRepository { get; }
        ICategoryRepository CategoryRepository { get; } 
        IProductRepository ProductRepository { get; }
        IQuestionRepository QuestionRepository { get; }
    }
}
