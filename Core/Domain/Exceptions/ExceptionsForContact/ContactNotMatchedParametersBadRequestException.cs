namespace Domain.Exceptions.ExceptionsForContact
{
    public class ContactNotMatchedParametersBadRequestException : BadRequestException
    {
        public ContactNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak request headers içerisinde gönderilen  Id : {id} ile Object.Id eşleşmemektedir.")
        {
        }
    }
}
