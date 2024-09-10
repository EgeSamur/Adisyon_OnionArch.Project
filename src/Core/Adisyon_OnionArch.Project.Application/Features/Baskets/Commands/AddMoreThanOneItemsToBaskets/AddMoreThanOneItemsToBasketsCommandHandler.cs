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

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.AddMoreThanOneItemsToBaskets
{
    public class AddMoreThanOneItemsToBasketsCommandHandler : BaseHandler, IRequestHandler<AddMoreThanOneItemsToBasketsCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        private readonly BasketRules _basketRules;
        public AddMoreThanOneItemsToBasketsCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules, BasketRules basketRules) : base(mapper, unitOfWork, httpContextAccessor)
        {

            _productRules = productRules;
            _basketRules = basketRules;
        }

        public async Task<Unit> Handle(AddMoreThanOneItemsToBasketsCommandRequest request, CancellationToken cancellationToken)
        {
            // Sepeti al
            Basket? basket = await _unitOfWork.GetReadRepository<Basket>().GetAsync(x => x.TableId == request.TableId && x.IsPaid == true,
                include: x => x.Include(z => z.BucketItems),
                enableTracking: true);
            await _basketRules.EnsureBasketIsExist(basket);

            // Her ürün için işlem yap
            foreach (var itemDto in request.BasketItems)
            {
                // Ürünü kontrol et
                Domain.Entities.Product? product = await _unitOfWork.GetReadRepository<Domain.Entities.Product>().GetAsync(x => x.Id == itemDto.ProductId);
                await _productRules.EnsureProducExists(product);

                // Sepette bu ürün var mı kontrol et
                var existingItem = basket.BucketItems?.FirstOrDefault(b => b.ProductId == itemDto.ProductId);
                if (existingItem != null)
                {
                    // Eğer ürün varsa miktarı artır
                    existingItem.Quantity += itemDto.Quantity;
                }
                else
                {
                    // Yeni ürün ekle
                    var basketItem = new BasketItem
                    {
                        Id = Guid.NewGuid(),
                        BasketId = basket.Id,
                        ProductId = itemDto.ProductId,
                        Quantity = itemDto.Quantity,
                        CreatedByUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null
                    };

                    await _unitOfWork.GetWriteRepository<BasketItem>().AddAsync(basketItem);
                }
            }

            // Sepeti güncelle
            basket.IsPaid = false; // artık ödenmesi gereken birşeyler var
            basket.UpdatedDate = DateTime.UtcNow;
            basket.UpdatedByUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            await _unitOfWork.GetWriteRepository<Basket>().UpdateAsync(basket);
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
