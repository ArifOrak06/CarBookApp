namespace Domain.Exceptions.ExceptionsForPricing
{
    public sealed class PricingObjectNullBadRequestException : BadRequestException
    {
        public PricingObjectNullBadRequestException() : base("Parametre olarak gönderilen object null")
        {
        }
    }
}
