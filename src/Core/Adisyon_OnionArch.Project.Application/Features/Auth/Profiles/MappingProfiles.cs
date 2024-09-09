using Adisyon_OnionArch.Project.Application.Dtos;
using Adisyon_OnionArch.Project.Application.Features.Auth.Command.Register;
using Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetCategoryById;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Auth.User, RegisterCommandRequest>().ReverseMap();
        }
    }
}
