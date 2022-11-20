using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.RequestModels.CategoryRequests
{
    public class AddCategoryRequest
    {
        public string Title { get; set; }
        public string UaTitle { get; set; }
        public int Rating { get; set; }
        public IFormFile Image { get; set; }
    }
}
