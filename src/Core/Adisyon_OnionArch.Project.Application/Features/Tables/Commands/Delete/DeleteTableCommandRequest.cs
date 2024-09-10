using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Common.QrCodeHelpers;
using Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Create;
using Adisyon_OnionArch.Project.Application.Features.Tables.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Delete
{
    public class DeleteTableCommandRequest : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    
}
