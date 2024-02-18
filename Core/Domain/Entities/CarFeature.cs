namespace Domain.Entities
{
    public class CarFeature
    {
        public int Id { get; set; }
        public bool Available { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = new();
        public int FeatureId { get; set; }
        public Feature Feature { get; set; } = new();

    }
}
