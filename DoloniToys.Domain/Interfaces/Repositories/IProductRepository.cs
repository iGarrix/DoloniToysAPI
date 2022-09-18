using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Domain.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product, Guid>
    {
    }
}
