using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.RequestModels.ProductRequests;
using DoloniToys.Domain.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoloniToysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost(ProductPaths.Add)]
        public ProductDto AddProduct([FromForm] AddProductRequest request)
        {
            ProductDto createdProduct = _productService.AddProduct(request);
            return createdProduct;
        }

        [HttpGet(ProductPaths.GetAll)]
        public PaginationResponse<ProductDto> GetAll(int page = 1, int take = 1)
        {
            return _productService.GetAllProduct(page, take);
        }

        [HttpGet(ProductPaths.Get)]
        public ProductDto GetProduct(string article)
        {
            return _productService.GetProduct(article);
        }

        [HttpGet(ProductPaths.GetFilter)]
        public PaginationResponse<ProductDto> GetProductsByCategory(string categoryTitle, string filterParam, int page = 1, int take = 1)
        {
            return _productService.GetProductsByCategory(categoryTitle, page, take, filterParam);
        }

        [HttpPut(ProductPaths.Change)]
        public ProductDto ChangeCategory([FromForm] ChangeProductRequest request)
        {
            return _productService.ChangeProduct(request);
        }

        [HttpDelete(ProductPaths.Remove)]
        public bool RemoveCategory([FromBody] string article)
        {
            return _productService.RemoveProduct(article);
        }
    }
}
