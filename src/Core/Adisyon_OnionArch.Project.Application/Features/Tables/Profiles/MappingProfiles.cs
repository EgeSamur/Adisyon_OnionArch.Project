using Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Create;
using Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetAllTablesByPaging;
using Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetTableById;
using AutoMapper;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Table, CreateTableCommandRequest>().ReverseMap();
            CreateMap<Domain.Entities.Table, GetAllTablesByPagingQueryResponse>().ReverseMap();

            // Table -> GetTableByIdQueryResponse
            // Mapping Table to GetTableByIdQueryResponse
            CreateMap<Domain.Entities.Table, GetTableByIdQueryResponse>()
                .ForMember(dest => dest.Basket, opt => opt.MapFrom(src => src.Basket))
                .ForMember(dest => dest.QrCode, opt => opt.MapFrom(src => src.QrCode));
            
        }
    }
}
