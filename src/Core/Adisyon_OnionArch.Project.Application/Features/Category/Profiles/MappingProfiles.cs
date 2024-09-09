using Adisyon_OnionArch.Project.Application.Dtos;
using Adisyon_OnionArch.Project.Application.Features.Category.Command.Create;
using Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetAllCategoriesWithPaging;
using Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetCategoryById;
using AutoMapper;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Category, GetCategoryByIdQueryResponse>().ReverseMap();
            CreateMap<Domain.Entities.Category, CategoryDto>().ReverseMap();
            CreateMap<Domain.Entities.Category, GetAllCategoriesWithPagingQueryResponse>().ReverseMap();
            CreateMap<Domain.Entities.Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<GetCategoryByIdQueryResponse, CategoryDto>().ReverseMap();
        }
    }
}
