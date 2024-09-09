using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Dtos;
using Adisyon_OnionArch.Project.Application.Features.Category.Rules;
using AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryHandler : BaseHandler, IRequestHandler<GetCategoryByIdQueryRequest, GetCategoryByIdQueryResponse>
    {
        private readonly CategoryRules _categoryRules;
        public GetCategoryByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _categoryRules = categoryRules;
        }

        public async Task<GetCategoryByIdQueryResponse> Handle(GetCategoryByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category? category = await _unitOfWork.GetReadRepository<Domain.Entities.Category>().GetAsync(x => x.Id == request.Id);
            await _categoryRules.EnsureCategoryIsExists(category);

            var categoryDto = _mapper.Map<CategoryDto>(category);
            var response = _mapper.Map<GetCategoryByIdQueryResponse>(categoryDto);

            return response;

        }
    }
}
