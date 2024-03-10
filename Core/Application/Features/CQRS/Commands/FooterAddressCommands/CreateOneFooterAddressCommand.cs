using Application.Features.CQRS.Results.FooterAddressResults;
using MediatR;

namespace Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class CreateOneFooterAddressCommand : IRequest<CreateOneFooterAddressCommandResult>
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
