using Application.Features.CQRS.Results.FooterAddressResults;
using MediatR;

namespace Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class RemoveOneFooterAddressCommand : IRequest<RemoveOneFooterAddressCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneFooterAddressCommand(int id)
        {
            Id = id;
        }
    }
}
