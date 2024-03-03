using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class Car : BaseEntity, IEntity
    {

        public int BrandId { get; set; }
        public Brand Brand { get; set; } 
        public List<CarFeature> CarFeeatures { get; set; }
        public string Model { get; set; } 
        public string CoverImageUrl { get; set; }
        public int Km { get; set; }
        public string Transmission { get; set; }
        public int Luggage { get; set; }
        public int Seat { get; set; }
        public string Fuel { get; set; }
        public string BigImageUrl { get; set; }
        public List<CarDescription> CarDescriptions { get; set; } 
        public List<CarsPricing> CarsPricings { get; set; } 

    }
}
