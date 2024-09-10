using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Tables.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SendGrid;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetTableById
{
    public class GetTableByIdQueryHandler : BaseHandler, IRequestHandler<GetTableByIdQueryRequest, GetTableByIdQueryResponse>
    {
        private readonly TablesRules _tableRules;
        public GetTableByIdQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, TablesRules tableRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _tableRules = tableRules;
        }

        public async Task<GetTableByIdQueryResponse> Handle(GetTableByIdQueryRequest request, CancellationToken cancellationToken)
        {
            //var table = await _unitOfWork.GetReadRepository<Domain.Entities.Table>().GetAsync(x => x.Id == request.Id, enableTracking: true,
            //    include: x => x.Include(z => z.QrCode).Include(a => a.Basket).ThenInclude(x=>x.BucketItems));
            var table = await _unitOfWork.GetReadRepository<Domain.Entities.Table>()
                                .GetAsync(x => x.Id == request.Id, enableTracking: true,
                                        include: x => x.Include(z => z.QrCode)
                                                                             .Include(a => a.Basket)
                                                                              .ThenInclude(b => b.BucketItems)
                                                                                    .ThenInclude(c => c.Product));
            await _tableRules.EnsureIsTableExists(table);
            decimal total = 0;
            if (table.Basket.BucketItems is not null)
            {
                foreach (var item in table.Basket.BucketItems)
                {
                    total += item.Product.Price;
                }
            }
            var response = _mapper.Map<GetTableByIdQueryResponse>(table);
            response.TotalPrice = total;
            return response;
        }
    }
}
