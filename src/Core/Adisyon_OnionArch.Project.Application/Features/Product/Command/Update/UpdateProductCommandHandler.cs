using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules;
using AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Command.Update
{
    public class UpdateProductCommandHandler : BaseHandler, IRequestHandler<UpdateProductCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        public UpdateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            //Domain.Entities.Product? product = await _unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAsync(x => x.Id == request.Id);
            //await _productRules.EnsureProducExists(product);
            //var mappedProduct = _mapper.Map<Domain.Entities.Product, UpdateProductCommandRequest>(request);
            //var productCategories = await _unitOfWork.GetReadRepository<Domain.Entities.ProductCategory>().GetAllAsync(x => x.ProductId == product.Id);
            //await _unitOfWork.GetWriteRepository<Domain.Entities.ProductCategory>().HardDeleteRangeAsync(productCategories); // burda Cascede değilse hata verebilir bakacağız.

            //var userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x=> x.Type == ClaimTypes.NameIdentifier);
            //var userId = userIdClaim != null ? Guid.Parse(userIdClaim.Value) : Guid.Empty;

            //foreach (var categoryIds in request.CategoryIds) 
            //{
            //    await _unitOfWork.GetWriteRepository<Domain.Entities.ProductCategory>().AddAsync(new()
            //    {
            //        Id = Guid.NewGuid(),
            //        CategoryId = categoryIds,
            //        ProductId = product.Id,
            //        CreatedByUserId = userId,
            //        UpdatedByUserId = userId,
            //        UpdatedDate = DateTime.UtcNow,
            //    });
            //}
            //await _unitOfWork.GetWriteRepository<Domain.Entities.Product>().UpdateAsync(product);
            //await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
