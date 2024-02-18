namespace Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = new();
        public List<CarFeature> CarFeeatures { get; set; } = new();
        public string Model { get; set; } = null!;
        public string? CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string? Transmission { get; set; }
        public byte Luggage { get; set; }
        public byte Seat { get; set; }
        public string? Fuel { get; set; }
        public string? BigImageUrl { get; set; }
        public List<CarDescription> CarDescriptions { get; set; } = new();
        public List<CarsPricing> CarsPricings { get; set; } = new();

    }
}
