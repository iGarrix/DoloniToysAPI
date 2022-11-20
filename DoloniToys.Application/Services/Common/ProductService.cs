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
                UaTitle = request.UaTitle,
                UaDescription = request.UaDescription,
                Description = request.Description,
                Rating = request.Rating,    
                Article = request.Article,
                Size = request.Size,
                Images = string.Join("/NEXT/", copyImages),
                Category = category,
            };

            Product createdProduct = _repositoryWrapper.ProductRepository.Add(newProduct);
            return createdProduct.ToDto<Product, ProductDto>(_mapper);
        }

        public ProductDto EditImage(EditImagesProductRequest request)
        {
            if (request is null)
            {
                throw new BadHandler();
            }

            Product findProduct = _repositoryWrapper.ProductRepository.Items.FirstOrDefault(x => x.Article == request.Article);
            if (findProduct is null)
            {
                throw new NotFoundHandler();
            }
            try
            {
                ImageManager.RemoveImage(request.ImageKey, Path.Combine(ImagePaths.Root, ImagePaths.Product));
                string newImageKey = ImageManager.CopyImage(request.NewImage, Path.Combine(ImagePaths.Root, ImagePaths.Product));
                string newImages = findProduct.Images.Replace(request.ImageKey, newImageKey);
                findProduct.Images = newImages;
                _repositoryWrapper.ProductRepository.Change(findProduct);
                return findProduct.ToDto<Product, ProductDto>(_mapper);
            }
            catch (Exception ex)
            {
                throw new BadHandler(ex.Message);
            }
            throw new BadHandler("Detected some problem");
        }

        public PaginationResponse<ProductDto> GetAllProduct(int page = 1, int take = 1)
        {
            PaginationResponse<ProductDto> paginateProduct = Pagination.PaginateToDtos<Product, ProductDto>(new PaginationParams<Product>()
            {
                TData = _repositoryWrapper.ProductRepository.Items.OrderByDescending(f => f.Create),
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

            PaginationResponse<ProductDto> paginateProduct = default(PaginationResponse<ProductDto>);
            if (categoryTitle == "*")
            {
                paginateProduct = Pagination.PaginateToDtos<Product, ProductDto>(new PaginationParams<Product>()
                {
                    TData = _repositoryWrapper.ProductRepository.Items.Include(x => x.Category).OrderByDescending(f => f.Create).Expression(filterParam),
                    CurrentPage = page,
                    Take = take,
                }, _mapper);
            }
            else
            {
                Category category = _repositoryWrapper.CategoryRepository.Items.FirstOrDefault(x => x.Title == categoryTitle);
            
                if (category is null)
                {
                    throw new NotFoundHandler();
                }

                paginateProduct = Pagination.PaginateToDtos<Product, ProductDto>(new PaginationParams<Product>()
                {
                    TData = _repositoryWrapper.ProductRepository.Items.Include(x => x.Category).Where(x => x.Category.Title == category.Title).OrderByDescending(f => f.Create).Expression(filterParam),
                    CurrentPage = page,
                    Take = take,
                }, _mapper);

            }
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
                product.UaTitle = request.NewUaTitle;
                product.Description = request.NewDescription;
                product.UaDescription = request.NewUaDescription;
                product.Size = request.NewSize;
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
                Console.WriteLine(article);
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
