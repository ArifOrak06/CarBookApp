using Application.Features.CQRS.Results.CarResults;
using MediatR;

namespace Application.Features.CQRS.Commands.CarCommands
{
    public class RemoveOneCarCommand : IRequest<RemoveOneCarCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneCarCommand(int id)
        {
            Id = id;
        }
    }
}
