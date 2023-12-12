namespace ProjectBase.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
