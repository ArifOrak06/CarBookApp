namespace Domain.Exceptions.ExceptionForBanner
{
    public sealed class BannerNotMatchedParametersBadRequestException : BadRequestException
    {
        public BannerNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen Id: {id} ile parametre obje Id eşleşmemektedir.")
        {
            
        }
    }
}
