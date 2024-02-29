namespace Domain.Entities
{
    public class Pricing
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public List<CarsPricing> CarsPricings { get; set; } 

    }
}
