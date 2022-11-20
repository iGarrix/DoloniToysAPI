using DoloniToys.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Dtos.Common
{
    public class CategoryDto : BaseDtoModel
    {
        public string Title { get; set; }
        public string UaTitle { get; set; } = "";
        public string Image { get; set; }
        public int Rating { get; set; }
    }
}
