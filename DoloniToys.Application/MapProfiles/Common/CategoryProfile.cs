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
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Title, source => source.MapFrom(src => src.Title))
                .ForMember(dest => dest.Create, source => source.MapFrom(src => src.Create))
                .ForMember(dest => dest.Image, source => source.MapFrom(src => src.Image));
        }
    }
}
