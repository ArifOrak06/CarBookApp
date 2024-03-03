using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class Category : BaseEntity, IEntity
    {

        public string Description { get; set; }
    }
}
