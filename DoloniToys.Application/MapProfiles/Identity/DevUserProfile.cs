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
    public class DevUserProfile : Profile
    {
        public DevUserProfile()
        {
            CreateMap<DevUser, DevUserDto>()
                .ForMember(dest => dest.Email, source => source.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, source => source.MapFrom(src => src.PhoneNumber));
        }
    }
}
