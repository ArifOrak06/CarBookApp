namespace Domain.Exceptions
{
    public sealed class AboutObjextNullBadRequestException : BadRequestException
    {
        public AboutObjextNullBadRequestException() :base ("Parametre olarak gönderilen obje boş")
        {
            
        }
    }
}
