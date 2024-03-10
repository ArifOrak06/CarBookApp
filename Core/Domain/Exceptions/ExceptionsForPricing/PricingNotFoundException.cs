namespace Domain.Exceptions.ExceptionsForPricing
{
    public sealed class PricingNotFoundException : NotFoundException
    {
        public PricingNotFoundException(int id) : base($"Pricing with Id : {id} couldn't found.")
        {
        }
    }
}
