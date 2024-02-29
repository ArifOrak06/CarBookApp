namespace Domain.Exceptions.ExceptionsForBrand
{
    public sealed class BrandObjectNullBadRequestException : BadRequestException
    {
        public BrandObjectNullBadRequestException() : base("Parametre olarak gönderilen Object null")
        {
        }
    }
}
