namespace Domain.Exceptions.ExceptionsForLocation
{
    public sealed class LocationNotFoundException : NotFoundException
    {
        public LocationNotFoundException(int id) : base($"Location with Id : {id} couldn't found.")
        {
        }
    }
}
