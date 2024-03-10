namespace Domain.Exceptions.ExceptionsForProvidedService
{
    public sealed class ProvidedServiceNotMatchedParametersBadRequestException : BadRequestException
    {
        public ProvidedServiceNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak rotadan gönderilen Id : {id} ile parametre olarak request.body içerisinde gönderilen object.Id bilgileri eşleşmemektedir.")
        {
        }
    }
}
