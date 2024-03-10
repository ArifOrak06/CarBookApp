namespace Domain.Exceptions.ExceptionsForLocation
{
    public sealed class LocationObjectNullBadRequestException : BadRequestException
    {
        public LocationObjectNullBadRequestException() : base("Parametre olarak gönderilen location varlığı null.")
        {
        }
    }
}
