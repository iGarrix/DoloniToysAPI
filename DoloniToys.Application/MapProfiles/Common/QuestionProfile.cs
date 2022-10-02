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
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionDto>()
                .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email))
                .ForMember(dest => dest.Message, source => source.MapFrom(src => src.Message))
                .ForMember(dest => dest.Create, source => source.MapFrom(src => src.Create));
        }
    }
}
