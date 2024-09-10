using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Baskets.Rules;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules;
using Adisyon_OnionArch.Project.Application.Features.Tables.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddItemsToBaskets
{
    public class AddItemsToBasketCommandHandler : BaseHandler, IRequestHandler<AddItemsToBasketCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        private readonly TablesRules _tableRules;
        private readonly BasketRules _basketRules;
        public AddItemsToBasketCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules, TablesRules tableRules, BasketRules basketRules) : base(mapper, unitOfWork, httpContextAccessor)
        {

            _productRules = productRules;
            _tableRules = tableRules;
            _basketRules = basketRules;
        }

        public async Task<Unit> Handle(AddItemsToBasketCommandRequest request, CancellationToken cancellationToken)
        {
            Basket? basket = await _unitOfWork.GetReadRepository<Basket>().GetAsync(x => x.TableId == request.TableId && x.IsPaid == true,
                include: x => x.Include(z => z.BucketItems),
                enableTracking: true );
            await _basketRules.EnsureBasketIsExist(basket);

            Domain.Entities.Product? product = await _unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAsync(x => x.Id == request.ProductId);
            await _productRules.EnsureProducExists(product);
            // Sepette bu ürün var mı kontrol et
            var existingItem = basket.BucketItems?.FirstOrDefault(b => b.ProductId == request.ProductId);
            if (existingItem != null)
            {
                // Eğer ürün varsa miktarı artır
                existingItem.Quantity += request.Quantity;
            }
            else
            {
                // Yeni ürün ekle
                var basketItem = new BasketItem
                {
                    Id = Guid.NewGuid(),
                    BasketId = basket.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity,
                    CreatedByUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null
                };

                await _unitOfWork.GetWriteRepository<BasketItem>().AddAsync(basketItem);
            }

            basket.IsPaid = false; // artık ödenmesi gereken birşeyler var
            basket.UpdatedDate = DateTime.UtcNow;
            basket.UpdatedByUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            await _unitOfWork.GetWriteRepository<Basket>().UpdateAsync(basket);
            await _unitOfWork.SaveAsync();

            return Unit.Value;

        }
    }
}
