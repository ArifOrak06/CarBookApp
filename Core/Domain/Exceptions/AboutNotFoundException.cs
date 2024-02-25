namespace Domain.Exceptions
{
    public sealed class AboutNotFoundException : NotFoundException
    {
        public AboutNotFoundException(int id) : base($"About with id:{id} couldn't found.")
        {
            
        }
    }
}
