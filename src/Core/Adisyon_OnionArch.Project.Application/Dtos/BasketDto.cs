namespace Adisyon_OnionArch.Project.Application.Dtos
{
    public class BasketDto
    {
        public Guid Id { get; set; }
        public bool IsPaid { get; set; }
        public ICollection<BasketItemDto>? Items { get; set; }

    }
}
