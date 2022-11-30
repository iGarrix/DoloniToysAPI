using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.RequestModels.CategoryRequests;
using DoloniToys.Domain.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoloniToysApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost(CategoryPaths.Add)]
        [Authorize]
        public CategoryDto AddCategory([FromForm] AddCategoryRequest request)
        {
            CategoryDto createdCategory = _categoryService.AddCategory(request);
            return createdCategory;
        }

        [HttpGet(CategoryPaths.GetAll)]
        public PaginationResponse<CategoryDto> GetAll(int page = 1, int take = 1)
        {
            return _categoryService.GetAllCategory(page, take);
        }

        [HttpGet(CategoryPaths.Get)]
        public CategoryDto GetCategory(string title)
        {
            return _categoryService.GetCategory(title);
        }

        [HttpPut(CategoryPaths.Change)]
        [Authorize]
        public CategoryDto ChangeCategory([FromForm] ChangeCategoryRequest request)
        {
            return _categoryService.ChangeCategory(request);
        }

        [HttpDelete(CategoryPaths.Remove)]
        [Authorize]
        public bool RemoveCategory([FromBody]string title)
        {
            return _categoryService.RemoveCategory(title);
        }
    }
}
