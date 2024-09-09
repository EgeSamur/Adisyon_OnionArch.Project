using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Category.Rules;
using AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Delete
{
    public class DeleteCategoryCommandHandler : BaseHandler, IRequestHandler<DeleteCategoryCommandRequest, Unit>
    {
        private readonly CategoryRules _categoryRules;
        public DeleteCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // Mevcut Category'yi alıyoruz
            Domain.Entities.Category? category = await _unitOfWork.GetReadRepository<Domain.Entities.Category>()
                .GetAsync(x => x.Id == request.Id);

            await _categoryRules.EnsureCategoryIsExists(category);

            Claim? userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

            if (userIdClaim != null)
            {
                var userId = Guid.Parse(userIdClaim.Value);
                category.DeleteddByUserId = userId;
            }

            category.IsDeleted = true;
            category.DeletedDate = DateTime.UtcNow;

            await _unitOfWork.GetWriteRepository<Domain.Entities.Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();
           
            return Unit.Value;
        }
    }
}