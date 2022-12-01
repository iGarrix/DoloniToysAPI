using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.RequestModels.ProductRequests
{
    public class ChangeProductRequest
    {
        public string Article { get; set; }
        public string? CategoryTitle { get; set; }
        public string NewTitle { get; set; }
        public string NewUaTitle { get; set; }
        public string NewDescription { get; set; }
        public string NewUaDescription { get; set; }
        public int NewRating { get; set; }
        public string NewArticle { get; set; }
        public string NewSize { get; set; }
        public string NewBoxSize { get; set; }
    }
}
