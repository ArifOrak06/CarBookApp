namespace Domain.Exceptions.ExceptionsForCategory
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id) : base($"Category with Id: {id} couldn't found.")
        {
            
        }
    }
}
