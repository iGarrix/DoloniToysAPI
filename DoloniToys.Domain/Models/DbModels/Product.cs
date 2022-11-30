using DoloniToys.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Models.DbModels
{
    public class Product : BaseDbModel<Guid>
    {
        public string Title { get; set; }
        public string UaTitle { get; set; } = "";
        public string Images { get; set; }
        public string Description { get; set; }
        public string UaDescription { get; set; } = "";
        public int Rating { get; set; }
        public string Article { get; set; }
        public string Size { get; set; } = "";
        public string BoxSize { get; set; } = "";
        public virtual Category Category { get; set; }
    }
}
