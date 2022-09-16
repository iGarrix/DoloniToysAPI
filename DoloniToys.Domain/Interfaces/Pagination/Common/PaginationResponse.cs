using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Pagination.Common
{
    public class PaginationResponse<TData>
    {
        public int TotalObj { get; set; } = -1;
        public int Total { get; set; } = -1;
        public int CurrentPage { get; set; } = -1;
        public int NextPage { get; set; } = -1;
        public int PrevPage { get; set; } = -1;
        public int Takes { get; set; } = -1;

        public IEnumerable<TData> Pageables { get; set; }
    }
}
