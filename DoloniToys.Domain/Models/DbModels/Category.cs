using DoloniToys.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Models.DbModels
{
    public class Category : BaseDbModel<Guid>
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
