using FluentValidation;

namespace Adisyon_OnionArch.Project.Application.Features.Product.Command.Create
{
    public class CreateProductCommandValidation : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidation()
        {
            RuleFor(x=> x.Name).NotEmpty();
            RuleFor(x=> x.Description).MaximumLength(250);
            RuleFor(x=> x.Price).GreaterThan(0);
            RuleFor(x => x.IsBestSeller)
                .NotNull();
            // BestSellerRank sadece IsBestSeller true ise kontrol edilmeli
            When(x => x.IsBestSeller == true, () =>
            {
                RuleFor(x => x.BestSellerRank)
                    .NotNull().WithMessage("En iyi satıcı sırası, en iyi satıcı işaretliyse boş olamaz");
            });
            // CategoryIds varsa, en az bir kategori ID'si olmalı
            RuleFor(x => x.CategoryIds)
                .NotEmpty().When(x => x.CategoryIds != null).WithMessage("En az bir kategori seçilmelidir")
                .Must(categoryIds => categoryIds?.Count > 0).WithMessage("Geçerli kategori ID'leri gönderilmelidir")
                .Must(categories => categories.Any()); ;
        }
    }
}
