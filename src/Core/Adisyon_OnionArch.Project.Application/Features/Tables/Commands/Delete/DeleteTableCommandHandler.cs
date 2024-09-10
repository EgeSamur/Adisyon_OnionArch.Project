using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Tables.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Delete
{
    public class DeleteTableCommandHandler : BaseHandler, IRequestHandler<DeleteTableCommandRequest, Unit>
    {
        private readonly TablesRules _tablesRules;
        public DeleteTableCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, TablesRules tablesRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _tablesRules = tablesRules;
        }

        public async Task<Unit> Handle(DeleteTableCommandRequest request, CancellationToken cancellationToken)
        {
            var table = await _unitOfWork.GetReadRepository<Domain.Entities.Table>().GetAsync(x => x.Id == request.Id ,enableTracking:true ,include:x=>x.Include(z => z.Basket).Include(a=>a.QrCode));
            await _tablesRules.EnsureIsTableExists(table);
            table.IsDeleted = true;
            table.DeletedDate = DateTime.UtcNow;
            table.DeleteddByUserId = Guid.Parse(_userId);
            table.QrCode.IsDeleted = true;
            table.QrCode.DeletedDate = DateTime.UtcNow; ;
            table.QrCode.DeleteddByUserId = Guid.Parse(_userId);
            table.Basket.IsDeleted = true;
            table.Basket.DeletedDate = DateTime.UtcNow; ;
            table.Basket.DeleteddByUserId = Guid.Parse(_userId);

            await _unitOfWork.GetWriteRepository<Domain.Entities.Table>().UpdateAsync(table);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
