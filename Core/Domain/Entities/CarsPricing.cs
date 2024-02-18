namespace Domain.Entities
{
    public class CarsPricing
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; } = new();
        public int PricingId { get; set; }
        public Pricing Pricing { get; set; } = new();
        public decimal Amount { get; set; }
    }
}
