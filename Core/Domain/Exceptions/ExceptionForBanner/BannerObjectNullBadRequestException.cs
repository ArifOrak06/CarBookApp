namespace Domain.Exceptions.ExceptionForBanner
{
    public sealed class BannerObjectNullBadRequestException : BadRequestException
    {
        public BannerObjectNullBadRequestException() : base("Parametre olarak gönderilen banner objesi null")
        {
            
        }
    }
}
