using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Queries.GetAllProductsByPaging
{
    public class GetAllProductsByPagingQueryHandler : BaseHandler, IRequestHandler<GetAllProductsByPagingQueryRequest, List<GetAllProductsByPagingQueryResponse>>
    {
        public GetAllProductsByPagingQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<List<GetAllProductsByPagingQueryResponse>> Handle(GetAllProductsByPagingQueryRequest request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAllByPagingAsync(currentPage: request.CurrentPage, pageSize: request.PageSize, include: y => y.Include(x=>x.ProductCategories).ThenInclude(a=>a.Category));
            List<GetAllProductsByPagingQueryResponse> response = new List<GetAllProductsByPagingQueryResponse>();
            foreach (var product in products)
            {
                var mappedProduct = _mapper.Map<GetAllProductsByPagingQueryResponse>(product);
                response.Add(mappedProduct);
            }
            return response;
        }
    }
}
