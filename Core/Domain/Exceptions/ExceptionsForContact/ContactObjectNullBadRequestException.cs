namespace Domain.Exceptions.ExceptionsForContact
{
    public class ContactObjectNullBadRequestException : BadRequestException
    {
        public ContactObjectNullBadRequestException() : base("Parametre olarak gönderilen Contact varlığı null")
        {
        }
    }
}
