namespace Domain.Exceptions.ExceptionsForFooterAddress
{
    public sealed class FooterAddressNotFoundException : NotFoundException
    {
        public FooterAddressNotFoundException(int id) : base($"Footer Address with Id : {id} couldn't found.")
        {
        }
    }
}
