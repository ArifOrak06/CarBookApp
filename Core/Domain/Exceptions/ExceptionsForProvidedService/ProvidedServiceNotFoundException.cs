namespace Domain.Exceptions.ExceptionsForProvidedService
{
    public sealed class ProvidedServiceNotFoundException : NotFoundException
    {
        public ProvidedServiceNotFoundException(int id) : base($"Provided Service with Id : {id} couldn't found.")
        {
        }
    }
}
