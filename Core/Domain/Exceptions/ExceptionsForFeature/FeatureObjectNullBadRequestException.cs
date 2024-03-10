namespace Domain.Exceptions.ExceptionsForFeature
{
    public sealed class FeatureObjectNullBadRequestException : BadRequestException
    {
        public FeatureObjectNullBadRequestException() : base($"Parametre olarak gönderilen Feature varlığı null")
        {
        }
    }
}
