using Adisyon_OnionArch.Project.Application.Features.Product.Command.Create;
using Adisyon_OnionArch.Project.Application.Features.Product.Command.Update;
using Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetAllProductsByPaging;
using Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetProductById;
using AutoMapper;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Product, GetProductByIdQueryResponse>()
                .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Category)));

            CreateMap<Domain.Entities.Product, GetAllProductsByPagingQueryResponse>().ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Category))).ReverseMap();
               
            
            
            
            CreateMap<Domain.Entities.Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<Domain.Entities.Product, CreateProductCommandRequest>().ReverseMap();
        }
    }
}
