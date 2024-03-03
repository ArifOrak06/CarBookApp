namespace Domain.Exceptions.ExceptionsForCategory
{
    public class CategoryObjectNullBadRequestException : BadRequestException
    {
        public CategoryObjectNullBadRequestException() : base("Parametre olarak gönderilen object null")
        {
        }
    }
}
