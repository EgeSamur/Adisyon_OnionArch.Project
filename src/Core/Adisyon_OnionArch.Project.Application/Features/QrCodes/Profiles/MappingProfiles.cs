using Adisyon_OnionArch.Project.Application.Dtos;
using AutoMapper;

namespace Adisyon_OnionArch.Project.Application.Features.QrCodes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.QrCode, QrCodeDto>().ReverseMap();
        }
    }
}
