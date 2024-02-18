namespace Domain.Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<CarFeature> CarFeeatures { get; set; } = new();
    }
}
