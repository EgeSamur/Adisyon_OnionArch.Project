using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules;
using AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Command.Delete
{
    public class DeleteProductCommandHandler : BaseHandler, IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        public DeleteProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAsync(x => x.Id == request.Id);
            await _productRules.EnsureProducExists(product);
            product.DeletedDate = DateTime.UtcNow;
            product.IsDeleted = true;
            Claim? userIdClaim = _httpContextAccessor
                                  .HttpContext?
              .User
              .Claims
                                  .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                var userId = Guid.Parse(userIdClaim.Value);
                // Kullanıcı ID'sini CreatedByUserId alanına atıyoruz
                product.DeleteddByUserId = userId;
            }
            await _unitOfWork.GetWriteRepository<Domain.Entities.Product>().UpdateAsync(product);
            await _unitOfWork.SaveAsync();
            return Unit.Value;

        }
    }
}
