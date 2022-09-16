using AutoMapper;
using DoloniToys.Domain.Dtos.Identity;
using DoloniToys.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoloniToys.Application.MapProfiles.Identity
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Name, source => source.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, source => source.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Fax, source => source.MapFrom(src => src.Fax))
                .ForMember(dest => dest.Company, source => source.MapFrom(src => src.Company))
                .ForMember(dest => dest.Address, source => source.MapFrom(src => src.Address))
                .ForMember(dest => dest.City, source => source.MapFrom(src => src.City))
                .ForMember(dest => dest.Country, source => source.MapFrom(src => src.Country))
                .ForMember(dest => dest.Region, source => source.MapFrom(src => src.Region))
                .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, source => source.MapFrom(src => src.PhoneNumber));
        }
    }
}
