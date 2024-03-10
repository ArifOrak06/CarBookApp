using Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace Application.Features.CQRS.Commands.LocationCommands
{
    public class CreateOneLocationCommand : IRequest<CreateOneLocationCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
