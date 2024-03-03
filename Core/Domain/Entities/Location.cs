using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class Location : BaseEntity, IEntity
    {
        public string? Name { get; set; }

    }
}
