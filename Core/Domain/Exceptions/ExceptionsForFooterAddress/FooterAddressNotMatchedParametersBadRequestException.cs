namespace Domain.Exceptions.ExceptionsForFooterAddress
{
    public sealed class FooterAddressNotMatchedParametersBadRequestException : BadRequestException
    {
        public FooterAddressNotMatchedParametersBadRequestException(int id) : base($"Parametre olarak gönderilen route Id : {id} ile request body içerisinde gönderilen object.Id eşleşmemektedir.")
        {
        }
    }
}
