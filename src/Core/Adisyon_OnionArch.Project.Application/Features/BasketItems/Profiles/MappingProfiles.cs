using Adisyon_OnionArch.Project.Application.Dtos;
using AutoMapper;

namespace Adisyon_OnionArch.Project.Application.Features.BasketItems.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.BasketItem, BasketItemDto>().ReverseMap();

        }
    }
}
