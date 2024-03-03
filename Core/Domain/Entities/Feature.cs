using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class Feature : BaseEntity, IEntity
    {
        public string Name { get; set; } 
        public List<CarFeature> CarFeeatures { get; set; } 
    }
}
