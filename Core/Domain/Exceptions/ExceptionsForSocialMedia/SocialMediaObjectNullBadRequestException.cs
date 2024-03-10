namespace Domain.Exceptions.ExceptionsForSocialMedia
{
    public sealed class SocialMediaObjectNullBadRequestException : BadRequestException
    {
        public SocialMediaObjectNullBadRequestException() : base("Parametre olarak gönderilen object null")
        {
        }
    }
}
