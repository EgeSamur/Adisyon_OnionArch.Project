using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public class QrCode : EntityBase
    {
        public Guid TableId { get; set; } // Foreign key to Table
        public string Url { get; set; }
        public byte[] QrCodeImage { get; set; }

        // Navigation property
        public Table Table { get; set; }
    }
}
