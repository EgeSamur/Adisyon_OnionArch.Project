using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetTableById;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetAllTablesByPaging
{
    public class GetAllTablesByPagingQueryHandler : BaseHandler, IRequestHandler<GetAllTablesByPagingQueryRequest, List<GetAllTablesByPagingQueryResponse>>
    {
        public GetAllTablesByPagingQueryHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
        }

        public async Task<List<GetAllTablesByPagingQueryResponse>> Handle(GetAllTablesByPagingQueryRequest request, CancellationToken cancellationToken)
        {
            var tables = await _unitOfWork.GetReadRepository<Domain.Entities.Table>()
                              .GetAllByPagingAsync(enableTracking: true,
                                      include: x => x.Include(z => z.QrCode)
                                                                           .Include(a => a.Basket)
                                                                            .ThenInclude(b => b.BucketItems)
                                                                                  .ThenInclude(c => c.Product)
                                                                                  ,currentPage:request.CurrentPage
                                                                                  ,pageSize:request.PageSize);
            List<GetAllTablesByPagingQueryResponse> response = new List<GetAllTablesByPagingQueryResponse>();

            foreach(var table in tables)
            {
                var mappedTable = _mapper.Map<GetAllTablesByPagingQueryResponse>(table);
                decimal total = 0;
                if (table.Basket.BucketItems is not null)
                {
                    foreach (var item in table.Basket.BucketItems)
                    {
                        total += item.Product.Price;
                    }
                }
                mappedTable.TotalPrice = total;
                response.Add(mappedTable);
            }
            return response;
        }
    }
}
