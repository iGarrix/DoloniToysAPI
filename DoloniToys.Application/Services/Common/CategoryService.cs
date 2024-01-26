using AutoMapper;
using DoloniToys.Application.Extensions.Expressions;
using DoloniToys.Application.Extensions.Identity;
using DoloniToys.Application.Extensions.Pagination;
using DoloniToys.Application.Helpers.ImageManager;
using DoloniToys.Application.Middlewares.ExceptionHandlingMiddleware.ExceptionHandlers;
using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Interfaces.Common;
using DoloniToys.Domain.Interfaces.Pagination.Common;
using DoloniToys.Domain.Interfaces.Services;
using DoloniToys.Domain.Models.DbModels;
using DoloniToys.Domain.RequestModels.CategoryRequests;
using DoloniToys.Domain.Resources;
using DoloniToys.Infrastructure.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Services.Common
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public CategoryService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public CategoryDto AddCategory(AddCategoryRequest request)
        {
            if (request is null)
            {
                throw new BadHandler();
            }

            string copyImage = ImageManager.CopyImage(request.Image, Path.Combine(ImagePaths.Root, ImagePaths.Category));
            
            Category newCategory = new Category()
            {
                Title = request.Title,
                UaTitle = request.UaTitle,
                Rating = request.Rating,
                Image = copyImage,
            };


            Category createdCategory = _repositoryWrapper.CategoryRepository.Add(newCategory);
            return createdCategory.ToDto<Category, CategoryDto>(_mapper);
        }

        public PaginationResponse<CategoryDto> GetAllCategory(int page = 1, int take = 1, string isEco = "standart")
        {
            PaginationResponse<CategoryDto> paginateCategory = Pagination.PaginateToDtos<Category, CategoryDto>(new PaginationParams<Category>()
            {
                TData = _repositoryWrapper.CategoryRepository.Items.OrderByDescending(f => f.Rating).SelectEco(isEco),
                CurrentPage = page,
                Take = take,
            }, _mapper);

            if (paginateCategory is null)
            {
                throw new BadHandler();
            }

            if (paginateCategory.Pageables.Count() == 0)
            {
                throw new NotFoundHandler();
            }

            return paginateCategory;
        }

        public CategoryDto GetCategory(string title)
        {
            var category = _repositoryWrapper.CategoryRepository.Items.FirstOrDefault(f => f.Title == title);
            if (category is null)
            {
                throw new NotFoundHandler();
            }

            return category.ToDto<Category, CategoryDto>(_mapper);
        }

        public CategoryDto ChangeCategory(ChangeCategoryRequest request)
        {
            Category category = _repositoryWrapper.CategoryRepository.Items.FirstOrDefault(x => x.Title == request.Title);
            if (category is not null)
            {
                if (request.NewImage is not null)
                {
                    ImageManager.RemoveImage(category.Image, Path.Combine(ImagePaths.Root, ImagePaths.Category));
                    string copyImage = ImageManager.CopyImage(request.NewImage, Path.Combine(ImagePaths.Root, ImagePaths.Category));
                    category.Image = copyImage;
                }
                category.Title = request.NewTitle;
                category.UaTitle = request.NewUaTitle;
                category.Rating = request.NewRating;
                _repositoryWrapper.CategoryRepository.Change(category);
                return category.ToDto<Category, CategoryDto>(_mapper);
            }
            throw new NotFoundHandler();
        }

        public bool RemoveCategory(string title)
        {
            Category category = _repositoryWrapper.CategoryRepository.Items.FirstOrDefault(x => x.Title == title);
            if (category is not null)
            {
                _repositoryWrapper.CategoryRepository.Delete(category.Id);
                ImageManager.RemoveImage(category.Image, Path.Combine(ImagePaths.Root, ImagePaths.Category));
                return true;
            }
            throw new NotFoundHandler();
        }
    }
}
