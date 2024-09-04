using Adisyon_OnionArch.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adisyon_OnionArch.Project.Persistance.Configrations
{
    public class QrCodeConfigrations : IEntityTypeConfiguration<QrCode>
    {
        public void Configure(EntityTypeBuilder<QrCode> builder)
        {
            builder.HasOne(q => q.Table)
                .WithOne(t => t.QrCode)
                .HasForeignKey<QrCode>(q => q.TableId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
