namespace Adisyon_OnionArch.Project.Domain.Common
{
    public class EntityBase : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public Guid? DeleteddByUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
