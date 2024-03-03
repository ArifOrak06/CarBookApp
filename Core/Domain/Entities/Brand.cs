using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class Brand : BaseEntity, IEntity
    {
        public string Name { get; set; } 
        public List<Car> Cars { get; set; } 
    }
}
