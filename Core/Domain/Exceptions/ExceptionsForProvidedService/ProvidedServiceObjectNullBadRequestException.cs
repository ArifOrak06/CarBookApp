namespace Domain.Exceptions.ExceptionsForProvidedService
{
    public sealed class ProvidedServiceObjectNullBadRequestException : BadRequestException
    {
        public ProvidedServiceObjectNullBadRequestException() : base("Parametre olarak gönderilen object null")
        {
        }
    }
}
