using Adisyon_OnionArch.Project.Application.Dtos;
using Adisyon_OnionArch.Project.Domain.Entities;
using AutoMapper;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Basket, BasketDto>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.BucketItems))
                .ReverseMap();
        }
    }
}
