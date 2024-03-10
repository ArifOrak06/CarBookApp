namespace Application.Features.CQRS.Results.FooterAddressResults
{
    public class RemoveOneFooterAddressCommandResult
    {
        public int Id { get; set; }
        public RemoveOneFooterAddressCommandResult(int id)
        {
            Id = id;
        }
    }
}
