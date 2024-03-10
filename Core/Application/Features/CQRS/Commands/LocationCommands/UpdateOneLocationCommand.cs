using Application.Features.CQRS.Results.LocationResults;
using MediatR;

namespace Application.Features.CQRS.Commands.LocationCommands
{
    public class UpdateOneLocationCommand : IRequest<UpdateOneLocationCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
