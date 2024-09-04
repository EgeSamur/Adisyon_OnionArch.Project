using Adisyon_OnionArch.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adisyon_OnionArch.Project.Persistance.Configrations
{
    public class BasketConfigration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            //builder.Property(x => x.TableId).IsRequired();
        }
    }
}
