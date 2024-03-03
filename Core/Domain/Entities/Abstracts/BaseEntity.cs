namespace Domain.Entities.Abstracts
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
