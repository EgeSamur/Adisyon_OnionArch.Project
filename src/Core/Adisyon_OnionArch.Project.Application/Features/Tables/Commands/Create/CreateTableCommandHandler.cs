using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Common.QrCodeHelpers;
using Adisyon_OnionArch.Project.Application.Features.Tables.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Commands.Create
{
    public class CreateTableCommandHandler : BaseHandler, IRequestHandler<CreateTableCommandRequest, Unit>
    {
        private readonly TablesRules _tablesRules;
        public CreateTableCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, TablesRules tablesRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _tablesRules = tablesRules;
        }

        public async Task<Unit> Handle(CreateTableCommandRequest request, CancellationToken cancellationToken)
        {
            var table = await _unitOfWork.GetReadRepository<Domain.Entities.Table>().GetAsync(x => x.TableNumberString == request.TableNumberString);
            await _tablesRules.EnsureTableDoesNotExist(table);

            Domain.Entities.Table newTable = _mapper.Map<Domain.Entities.Table>(request);
            newTable.Id = Guid.NewGuid();
            newTable.CreatedByUserId = Guid.Parse(_userId);

            // table Oluşturuldu.
            // qr code ve bucket oluşuturup bağlayacğız birbirine
            Basket newBasket = new()
            {
                Id = Guid.NewGuid(),
                Table = newTable,
                TableId = newTable.Id
            };

            newTable.Basket = newBasket;
            newTable.BasketId = newBasket.Id;
            newBasket.CreatedByUserId = Guid.Parse(_userId);

            
            //QrCode oluşturalım
            var crCodeByte = QrCodeHelper.GenerateQrCode(table.Id);
            QrCode qrCode = new()
            {
                Id = Guid.NewGuid(),
                CreatedByUserId = Guid.Parse(_userId),
                Url = $"https://localhost-my-adisyon-project.com/menu/{table.Id}",
                Table = newTable,
                TableId = newTable.Id,
                QrCodeImage = crCodeByte
            };

            newTable.QrCode = qrCode;
            newTable.QrCodeId = qrCode.Id;

            await _unitOfWork.GetWriteRepository<Domain.Entities.Table>().AddAsync(newTable);
            await _unitOfWork.GetWriteRepository<Basket>().AddAsync(newBasket);
            await _unitOfWork.GetWriteRepository<QrCode>().AddAsync(qrCode);

            await _unitOfWork.SaveAsync();


            return Unit.Value;

        }
    }
}