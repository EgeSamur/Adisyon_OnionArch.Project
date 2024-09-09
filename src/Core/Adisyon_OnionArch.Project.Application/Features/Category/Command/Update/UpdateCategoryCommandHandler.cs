using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Category.Rules;
using AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Update
{
    public class UpdateCategoryCommandHandler : BaseHandler, IRequestHandler<UpdateCategoryCommandRequest, Unit>
    {
        private readonly CategoryRules _categoryRules;
        public UpdateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            // Mevcut Category'yi alıyoruz
            Domain.Entities.Category? category = await _unitOfWork.GetReadRepository<Domain.Entities.Category>()
                .GetAsync(x => x.Id == request.Id, enableTracking: true);

            await _categoryRules.EnsureCategoryIsExists(category);

            Claim? userIdClaim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                var userId = Guid.Parse(userIdClaim.Value);
                category.UpdatedByUserId = userId;
            }

            category.Name = request.Name;
            category.Description = request.Description;
            category.UpdatedDate = DateTime.UtcNow;

            // Değişiklikleri kaydediyoruz
            await _unitOfWork.GetWriteRepository<Domain.Entities.Category>().UpdateAsync(category);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
