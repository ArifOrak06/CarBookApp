using Domain.Entities.Abstracts;

namespace Domain.Entities
{
    public class CarsPricing : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; }
        public decimal Amount { get; set; }
    }
}
