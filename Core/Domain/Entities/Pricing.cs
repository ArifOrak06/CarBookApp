using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class Pricing : BaseEntity, IEntity
    {
        public string Name { get; set; } 
        public List<CarsPricing> CarsPricings { get; set; } 

    }
}
