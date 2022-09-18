using DoloniToys.Domain.Interfaces.Repositories;
using DoloniToys.Domain.Models.DbModels;
using DoloniToys.Infrastructure.Context;
using DoloniToys.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(DataContext context) : base(context)
        {

        }
    }
}
