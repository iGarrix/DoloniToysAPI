using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.RequestModels.ProductRequests
{
    public class AddNewImageProductRequest
    {
        public string Article { get; set; }
        public IFormFile NewImage { get; set; }
    }
}
