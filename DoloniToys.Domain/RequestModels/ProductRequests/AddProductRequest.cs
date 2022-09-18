using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.RequestModels.ProductRequests
{
    public class AddProductRequest
    {
        public string Title { get; set; }
        public List<IFormFile> Images { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public string Article { get; set; }
        public string CategoryTitle { get; set; }
    }
}
