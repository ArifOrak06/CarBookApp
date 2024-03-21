using Application.Features.CQRS.Results.ContactResults;
using MediatR;

namespace Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveOneContactCommand : IRequest<RemoveOneContactCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneContactCommand(int id)
        {
            Id = id;
        }
    }
}
