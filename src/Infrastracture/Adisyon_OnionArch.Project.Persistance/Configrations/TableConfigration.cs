using Adisyon_OnionArch.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Adisyon_OnionArch.Project.Persistance.Configrations
{
    public class TableConfigration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.Property(x => x.TableNumberString).IsRequired();

            builder.HasOne(t => t.QrCode)
                   .WithOne(q => q.Table)
                   .HasForeignKey<Table>(t => t.QrCodeId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder
                .HasOne(t => t.QrCode)
                .WithOne(q => q.Table)
                .HasForeignKey<QrCode>(q => q.TableId) // Foreign key in QrCode
                .OnDelete(DeleteBehavior.Restrict); // or any other delete behavior
            builder
                .HasOne(t => t.Basket)
                .WithOne(b => b.Table)
                .HasForeignKey<Basket>(b => b.TableId) // Foreign key in Basket
                .OnDelete(DeleteBehavior.Restrict); // or any other delete behavior

          
        }
    }
}
