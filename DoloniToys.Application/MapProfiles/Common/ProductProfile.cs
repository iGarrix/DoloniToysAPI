using AutoMapper;
using DoloniToys.Domain.Dtos.Common;
using DoloniToys.Domain.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.MapProfiles.Common
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Title, source => source.MapFrom(src => src.Title))
                .ForMember(dest => dest.Create, source => source.MapFrom(src => src.Create))
                .ForMember(dest => dest.Images, source => source.MapFrom(src => src.Images))
                .ForMember(dest => dest.Description, source => source.MapFrom(src => src.Description))
                .ForMember(dest => dest.Rating, source => source.MapFrom(src => src.Rating))
                .ForMember(dest => dest.Article, source => source.MapFrom(src => src.Article));
        }
    }
}
