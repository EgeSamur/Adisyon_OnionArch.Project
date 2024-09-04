using Adisyon_OnionArch.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adisyon_OnionArch.Project.Persistance.Configrations
{
    public class BasketItemConfigration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            //builder.Property(x=>x.Id).IsRequired();
        }
    }
}
