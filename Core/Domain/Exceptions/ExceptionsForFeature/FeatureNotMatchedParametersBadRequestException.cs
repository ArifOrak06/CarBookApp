namespace Domain.Exceptions.ExceptionsForFeature
{
    public sealed class FeatureNotMatchedParametersBadRequestException : BadRequestException
    {
        public FeatureNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen route Id : {id} ile request body içerisinde gönderilen object.Id eşleşmemektedir.")
        {
        }
    }
}
