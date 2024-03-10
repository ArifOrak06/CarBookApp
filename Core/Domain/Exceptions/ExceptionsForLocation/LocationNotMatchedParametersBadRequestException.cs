namespace Domain.Exceptions.ExceptionsForLocation
{
    public sealed class LocationNotMatchedParametersBadRequestException : BadRequestException
    {
        public LocationNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen route ıd : {id} ile request -> body içerisinde gönderilen Location.Id eşleşmemektedir.")
        {
        }
    }
}
