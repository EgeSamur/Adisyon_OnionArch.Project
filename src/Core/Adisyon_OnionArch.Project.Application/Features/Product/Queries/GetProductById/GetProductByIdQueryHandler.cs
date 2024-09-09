using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : BaseHandler, IRequestHandler<GetProductByIdQueryRequest, GetProductByIdQueryResponse>
    {
        private readonly ProductRules _productRules;
        public GetProductByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
        }

        public async Task<GetProductByIdQueryResponse> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product? product = await _unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAsync(x => x.Id == request.Id, include:
                y => y.Include(z => z.ProductCategories.Where(x => x.ProductId == request.Id)).ThenInclude(x=> x.Category));
            await _productRules.EnsureProducExists(product);
            var productResponse = _mapper.Map<GetProductByIdQueryResponse>(product);

            return productResponse;

        }
    }
}
