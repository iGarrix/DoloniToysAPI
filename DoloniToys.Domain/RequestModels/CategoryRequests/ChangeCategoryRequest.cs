using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.RequestModels.CategoryRequests
{
    public class ChangeCategoryRequest
    {
        public string Title { get; set; }
        public string NewTitle { get; set; }
        public string NewUaTitle { get; set; }
        public int NewRating { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
