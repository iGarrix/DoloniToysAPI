using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.RequestModels.ProductRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Services
{
    public interface IProductService
    {
        ProductDto AddProduct(AddProductRequest request);
        PaginationResponse<ProductDto> GetAllProduct(int page = 1, int take = 1);
        ProductDto GetProduct(string article);
        PaginationResponse<ProductDto> GetProductsByCategory(string categoryTitle, int page = 1, int take = 1, string filterParam = "");
        ProductDto ChangeProduct(ChangeProductRequest request);
        bool RemoveProduct(string article);
    }
}
