using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Pagination.Common
{
    public class PaginationParams<TList>
    {
        public IQueryable<TList> TData { get; set; }
        public int Take { get; set; }
        public int CurrentPage { get; set; }
    }
}
