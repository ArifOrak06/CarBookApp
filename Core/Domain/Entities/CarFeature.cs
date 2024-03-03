using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class CarFeature : IEntity
    {
        public int Id { get; set; }
        public bool Available { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; } 

    }
}
