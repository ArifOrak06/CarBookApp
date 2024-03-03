namespace Domain.Exceptions.ExceptionsForCategory
{
    public class CategoryNotMatchedParametersBadRequestException : BadRequestException
    {
        public CategoryNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen Object Id: {id} ile headers'da gönderilen Id eşleşmemektedir.")
        {
        }
    }
}
