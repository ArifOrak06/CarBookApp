namespace Domain.Exceptions.ExceptionsForSocialMedia
{
    public sealed class SocialMediaNotMatchedParametersBadRequestException : BadRequestException
    {
        public SocialMediaNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak rotadan gönderilen Id : {id} ile parametre olarak request.body içerisinde gönderilen object.Id bilgileri eşleşmemektedir.")
        {
        }
    }
}
