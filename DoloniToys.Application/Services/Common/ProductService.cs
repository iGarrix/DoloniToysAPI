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
using DoloniToys.Domain.RequestModels.ProductRequests;
using DoloniToys.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.Services.Common
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        public ProductService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public ProductDto AddProduct(AddProductRequest request)
        {
            if (request is null)
            {
                throw new BadHandler();
            }

            Category category = _repositoryWrapper.CategoryRepository.Items.FirstOrDefault(x => x.Title == request.CategoryTitle);
            
            if (category is null)
            {
                throw new NotFoundHandler();
            }

            List<string> copyImages = new List<string>();

            foreach (var item in request.Images)
            {
                copyImages.Add(ImageManager.CopyImage(item, Path.Combine(ImagePaths.Root, ImagePaths.Product)));
            }


            Product newProduct = new Product()
            {
                Title = request.Title,
                Description = request.Description,
                Rating = request.Rating,    
                Article = request.Article,
                Images = string.Join("/NEXT/", copyImages),
                Category = category,
            };

            Product createdProduct = _repositoryWrapper.ProductRepository.Add(newProduct);
            return createdProduct.ToDto<Product, ProductDto>(_mapper);
        }

        public PaginationResponse<ProductDto> GetAllProduct(int page = 1, int take = 1)
        {
            PaginationResponse<ProductDto> paginateProduct = Pagination.PaginateToDtos<Product, ProductDto>(new PaginationParams<Product>()
            {
                TData = _repositoryWrapper.ProductRepository.Items,
                CurrentPage = page,
                Take = take,
            }, _mapper);

            if (paginateProduct is null)
            {
                throw new BadHandler();
            }

            if (paginateProduct.Pageables.Count() == 0)
            {
                throw new NotFoundHandler();
            }

            return paginateProduct;
        }


        public ProductDto GetProduct(string article)
        {
            Product product = _repositoryWrapper.ProductRepository.Items.FirstOrDefault(x => x.Article == article);
            if (product is not null)
            {
                return product.ToDto<Product, ProductDto>(_mapper);
            }
            throw new NotFoundHandler();
        }

        public PaginationResponse<ProductDto> GetProductsByCategory(string categoryTitle, int page = 1, int take = 1, string filterParam = "")
        {
            Category category = _repositoryWrapper.CategoryRepository.Items.FirstOrDefault(x => x.Title == categoryTitle);
            
            if (category is null)
            {
                throw new NotFoundHandler();
            }

            PaginationResponse<ProductDto> paginateProduct = Pagination.PaginateToDtos<Product, ProductDto>(new PaginationParams<Product>()
            {
                TData = _repositoryWrapper.ProductRepository.Items.Include(x => x.Category).Where(x => x.Category.Title == category.Title).Expression(filterParam),
                CurrentPage = page,
                Take = take,
            }, _mapper);

            if (paginateProduct is null)
            {
                throw new BadHandler();
            }

            if (paginateProduct.Pageables.Count() == 0)
            {
                throw new NotFoundHandler();
            }

            return paginateProduct;
        }

        public ProductDto ChangeProduct(ChangeProductRequest request)
        {
            Product product = _repositoryWrapper.ProductRepository.Items.FirstOrDefault(x => x.Article == request.Article);
            if (product is not null)
            {
                product.Title = request.NewTitle;
                product.Description = request.NewDescription;
                product.Rating = request.NewRating;
                product.Article = request.NewArticle;
                _repositoryWrapper.ProductRepository.Change(product);
                return product.ToDto<Product, ProductDto>(_mapper);
            }
            throw new NotFoundHandler();
        }

        public bool RemoveProduct(string article)
        {
            Product product = _repositoryWrapper.ProductRepository.Items.FirstOrDefault(x => x.Article == article);
            if (product is not null)
            {
                _repositoryWrapper.ProductRepository.Delete(product.Id);
                foreach (var item in product.Images.Split("/NEXT/", StringSplitOptions.None).ToList())
                {
                    ImageManager.RemoveImage(item, Path.Combine(ImagePaths.Root, ImagePaths.Product));
                }
                return true;
            }
            throw new NotFoundHandler();
        }
    }
}
