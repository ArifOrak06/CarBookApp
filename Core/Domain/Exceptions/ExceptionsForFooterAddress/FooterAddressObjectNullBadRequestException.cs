namespace Domain.Exceptions.ExceptionsForFooterAddress
{
    public sealed class FooterAddressObjectNullBadRequestException : BadRequestException
    {
        public FooterAddressObjectNullBadRequestException() : base("Parametre olarak gönderilen FooterAddress varlığı null")
        {
        }
    }
}
