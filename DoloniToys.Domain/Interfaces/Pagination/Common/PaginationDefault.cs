using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Pagination.Common
{
    public class PaginationDefault
    {
        public int Page { get; set; } = 1;
        public int Take { get; set; } = 1;
    }
}
