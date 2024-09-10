using Adisyon_OnionArch.Project.Application.Common.BaseHandlers;
using Adisyon_OnionArch.Project.Application.Features.Baskets.Rules;
using Adisyon_OnionArch.Project.Application.Features.Product.Rules;
using Adisyon_OnionArch.Project.Application.Interfaces.UnitOfWorks;
using Adisyon_OnionArch.Project.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Adisyon_OnionArch.Project.Application.Features.Baskets.Commands.PayForBasket
{
    public class PayForBasketCommandHandler : BaseHandler, IRequestHandler<PayForBasketCommandRequest, Unit>
    {
        private readonly ProductRules _productRules;
        private readonly BasketRules _basketRules;
        public PayForBasketCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, ProductRules productRules, BasketRules basketRules) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _productRules = productRules;
            _basketRules = basketRules;
        }

        public async Task<Unit> Handle(PayForBasketCommandRequest request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.GetReadRepository<Basket>().GetAsync(
           x => x.Id == request.BasketId && x.IsPaid == false,
           include: x => x.Include(b => b.BucketItems), // BucketItems ile birlikte getir
           enableTracking: true);

            await _basketRules.EnsureBasketIsExist(basket);

            // Sepetin içerisindeki tüm ürünleri (BucketItems) sil
            if (basket.BucketItems != null && basket.BucketItems.Any())
            {
                foreach (var item in basket.BucketItems)
                {
                    await _unitOfWork.GetWriteRepository<BasketItem>().HardDeleteAsync(item); // BucketItem'ları sil
                }
            }

            // Sepeti güncelle (IsPaid'i true yap)
            basket.IsPaid = true;
            basket.UpdatedByUserId = !string.IsNullOrEmpty(_userId) ? Guid.Parse(_userId) : (Guid?)null;
            basket.UpdatedDate = DateTime.UtcNow; // Güncelleme tarihi
            await _unitOfWork.GetWriteRepository<Basket>().UpdateAsync(basket);

            // Değişiklikleri kaydet
            await _unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
