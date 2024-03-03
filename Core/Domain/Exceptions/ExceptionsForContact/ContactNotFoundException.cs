namespace Domain.Exceptions.ExceptionsForContact
{
    public sealed class ContactNotFoundException : NotFoundException
    {
        public ContactNotFoundException(int id) : base($"Contact with Id : {id} couldn't found.")
        {
        }
    }
}
