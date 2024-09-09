using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Category.Rules;
using AutoMapper;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Adisyon_OnionArch.Project.Application.Features.Category.Command.Create
{
    public class CreateCategoryCommandHandler : BaseHandler, IRequestHandler<CreateCategoryCommandRequest, Unit>
    {
        private readonly CategoryRules _categoryRules;
        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, CategoryRules categoryRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _categoryRules = categoryRules;
        }

        public async Task<Unit> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Category? category = await _unitOfWork.GetReadRepository<Domain.Entities.Category>().GetAsync(predicate: x => x.Name.ToLower().Equals(request.Name.ToLower())
            && x.IsDeleted == false, enableTracking: false);
            await _categoryRules.EnsureCategoryIsNotExist(category);

            var newCategory = _mapper.Map<Domain.Entities.Category>(request);
            newCategory.Id = Guid.NewGuid();

            Claim? userIdClaim = _httpContextAccessor
                                .HttpContext?
                                .User
                                .Claims
                                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                var userId = Guid.Parse(userIdClaim.Value);
                // Kullanıcı ID'sini CreatedByUserId alanına atıyoruz
                newCategory.CreatedByUserId = userId;
            }
            // Veritabanına ekleme işlemi
            await _unitOfWork.GetWriteRepository<Domain.Entities.Category>().AddAsync(newCategory);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
