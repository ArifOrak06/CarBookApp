namespace Domain.Exceptions.ExceptionForBanner
{
    public sealed class BannerNotFoundException : NotFoundException
    {
        public BannerNotFoundException(int id) : base($"Banner with id:{id} couldn't found.")
        {
            
        }
    }
}
