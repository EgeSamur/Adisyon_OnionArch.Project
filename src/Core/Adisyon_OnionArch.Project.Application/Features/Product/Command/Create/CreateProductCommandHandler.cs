using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules;
using AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Command.Create
{
    public class CreateProductCommandHandler : BaseHandler, IRequestHandler<CreateProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productRules.EnsureProductDoesNotExist(request.Name);
            var mappedProcut = _mapper.Map<Domain.Entities.Product>(request);
            mappedProcut.Id = Guid.NewGuid();
            await _unitOfWork.GetWriteRepository<Domain.Entities.Product>().AddAsync(mappedProcut);
            Claim? userIdClaim = _httpContextAccessor
                                .HttpContext?
                                .User
                                .Claims
                                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                var userId = Guid.Parse(userIdClaim.Value);
                // Kullanıcı ID'sini CreatedByUserId alanına atıyoruz
                mappedProcut.CreatedByUserId = userId;
            }

            var result = await _unitOfWork.SaveAsync(); // db de böyle bir product oluşturulsun ki idsi olsun.
            if (result > 0)
            {
                foreach (var categoryId in request.CategoryIds)
                {
                    await _unitOfWork.GetWriteRepository<Domain.Entities.ProductCategory>().AddAsync(new Domain.Entities.ProductCategory()
                    {
                        Id = Guid.NewGuid(),
                        ProductId = mappedProcut.Id,
                        CategoryId = categoryId,
                        CreatedByUserId = Guid.Parse(_httpContextAccessor
                                .HttpContext?
                                .User
                                .Claims
                                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value),
                        CreatedDate = DateTime.Now,
                    });
                }
                await _unitOfWork.SaveAsync();
            }
            return Unit.Value;

        }
    }
}
