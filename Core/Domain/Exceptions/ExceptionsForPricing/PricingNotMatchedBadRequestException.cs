namespace Domain.Exceptions.ExceptionsForPricing
{
    public sealed class PricingNotMatchedBadRequestException : BadRequestException
    {
        public PricingNotMatchedBadRequestException(int id) : base($"Parametre olarak rotadan gönderilen Id : {id} ile parametre olarak request.body içerisinde gönderilen object.Id bilgileri eşleşmemektedir.")
        {
        }
    }
}
