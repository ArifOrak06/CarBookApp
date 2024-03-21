using Application.Features.CQRS.Results.AboutResults;
using MediatR;

namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class RemoveOneAboutCommand : IRequest<RemoveOneAboutCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneAboutCommand(int id)
        {
            Id = id;
        }
    }
}
