namespace Application.Features.CQRS.Results.FooterAddressResults
{
    public class CreateOneFooterAddressCommandResult
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
