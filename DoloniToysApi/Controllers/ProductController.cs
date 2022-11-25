using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.RequestModels.ProductRequests;
using DoloniToys.Domain.Resources;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public ProductDto AddProduct([FromForm] AddProductRequest request)
        {
            ProductDto createdProduct = _productService.AddProduct(request);
            return createdProduct;
        }

        [HttpPut(ProductPaths.ChangeImage)]
        [Authorize]
        public ProductDto EditImageInProduct([FromForm] EditImagesProductRequest request)
        {
            ProductDto updatedProduct = _productService.EditImage(request);
            return updatedProduct;
        }

        [HttpPut(ProductPaths.AddImage)]
        [Authorize]
        public ProductDto AddImageInProduct([FromForm] AddNewImageProductRequest request)
        {
            ProductDto updatedProduct = _productService.AddImage(request);
            return updatedProduct;
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
        [Authorize]
        public ProductDto ChangeCategory([FromBody] ChangeProductRequest request)
        {
            return _productService.ChangeProduct(request);
        }

        [HttpDelete(ProductPaths.Remove)]
        [Authorize]
        public bool RemoveCategory([FromBody] RemoveProductRequest data)
        {
            return _productService.RemoveProduct(data.Article);
        }
    }
}
