namespace Domain.Exceptions.ExceptionsForBrand
{
    public sealed class BrandNotFoundException : NotFoundException
    {
        public BrandNotFoundException(int id) : base($"Brand with Id:{id} could not found.")
        {
        }
    }
}
