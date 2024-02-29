namespace Domain.Exceptions.ExceptionsForBrand
{
    public sealed class BrandNotMatchedParametersBadRequestException : BadRequestException
    {
        public BrandNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen Id : {id} ile request body içerisinde gönderilen Object.Id eşleşmemektedir.")
        {
            
        }
    }
}
