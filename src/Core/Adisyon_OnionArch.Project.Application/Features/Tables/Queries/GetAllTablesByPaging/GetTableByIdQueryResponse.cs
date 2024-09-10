using Adisyon_OnionArch.Project.Application.Dtos;

namespace Adisyon_OnionArch.Project.Application.Features.Tables.Queries.GetAllTablesByPaging
{
    public class GetAllTablesByPagingQueryResponse
    {
        public Guid Id { get; set; }
        public string TableNumberString { get; set; }
        public decimal TotalPrice { get; set; } = 0;
        public Guid QrCodeId { get; set; }
        public BasketDto Basket { get; set; }
        public QrCodeDto QrCode { get; set; }
    }
}
