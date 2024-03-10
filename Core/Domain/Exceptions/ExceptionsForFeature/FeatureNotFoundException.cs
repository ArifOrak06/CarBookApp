namespace Domain.Exceptions.ExceptionsForFeature
{
    public sealed class FeatureNotFoundException : NotFoundException
    {
        public FeatureNotFoundException(int id) : base($"Feature with Id : {id} couldn't found.")
        {
        }
    }
}
