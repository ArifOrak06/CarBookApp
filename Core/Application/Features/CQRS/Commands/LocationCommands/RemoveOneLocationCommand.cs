using Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace Application.Features.CQRS.Commands.LocationCommands
{
    public class RemoveOneLocationCommand : IRequest<RemoveOneLocationCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneLocationCommand(int id)
        {
            Id = id;
        }
    }
}
