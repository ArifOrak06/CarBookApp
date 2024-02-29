namespace Domain.Exceptions.ExceptionsForBanner
{
    public sealed class BannerObjectNullBadRequestException : BadRequestException
    {
        public BannerObjectNullBadRequestException() : base("Parametre olarak gönderilen banner objesi null")
        {
            
        }
    }
}
