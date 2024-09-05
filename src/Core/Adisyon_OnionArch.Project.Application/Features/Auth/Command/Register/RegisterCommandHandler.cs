using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Interfaces.AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Adisyon_OnionArch.Project.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        public RegisterCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor ) 
            : base(mapper, unitOfWork, httpContextAccessor)
        {
            
        }
        public Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
