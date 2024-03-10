namespace Domain.Exceptions.ExceptionsForSocialMedia
{
    public sealed class SocialMediaNotFoundException : NotFoundException
    {
        public SocialMediaNotFoundException(int id) : base($"Social Media  with Id : {id} couldn't found.")
        {
        }
    }
}
