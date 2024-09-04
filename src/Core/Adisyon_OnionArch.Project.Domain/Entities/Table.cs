using Adisyon_OnionArch.Project.Domain.Common;

namespace Adisyon_OnionArch.Project.Domain.Entities
{
    public  class Table : EntityBase
    {
        public string TableNumberString { get; set; } // içeri 5. masa veya balkon 5. masa

        public Guid BasketId { get; set; }
        public Guid QrCodeId { get; set; }

        // Each table has one cart
        public Basket Basket { get; set; }

        // Each table can have one QR code
        public QrCode QrCode { get; set; }

    }
}
