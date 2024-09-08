using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Interfaces.AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetAllCategoriesWithPaging
{
    public class GetAllCategoriesWithPagingQueryHandler : BaseHandler, IRequestHandler<GetAllCategoriesWithPagingQueryRequest, IList<GetAllCategoriesWithPagingQueryResponse>>
    {
        public GetAllCategoriesWithPagingQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllCategoriesWithPagingQueryResponse>> Handle(GetAllCategoriesWithPagingQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.GetReadRepository<Domain.Entities.Category>().GetAllByPagingAsync(pageSize: request.PageSize, currentPage: request.CurrentPage);
            IList<GetAllCategoriesWithPagingQueryResponse> response = new List<GetAllCategoriesWithPagingQueryResponse>();
            foreach (var category in categories)
            {
                var map = _mapper.Map<GetAllCategoriesWithPagingQueryResponse, Domain.Entities.Category>(category);
                response.Add(map);
            }
            return response;
        }
    }
}
