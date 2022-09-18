using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.RequestModels.CategoryRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Domain.Interfaces.Services
{
    public interface ICategoryService
    {
        CategoryDto AddCategory(AddCategoryRequest request);
        PaginationResponse<CategoryDto> GetAllCategory(int page = 1, int take = 1);
        CategoryDto ChangeCategory(ChangeCategoryRequest request);
        bool RemoveCategory(string title);
    }
}
