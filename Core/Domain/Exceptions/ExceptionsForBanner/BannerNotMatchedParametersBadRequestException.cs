namespace Domain.Exceptions.ExceptionsForBanner
{
    public sealed class BannerNotMatchedParametersBadRequestException : BadRequestException
    {
        public BannerNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen Id: {id} ile parametre obje Id eşleşmemektedir.")
        {
            
        }
    }
}
