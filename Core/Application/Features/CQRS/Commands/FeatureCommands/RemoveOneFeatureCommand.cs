using Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
    public class RemoveOneFeatureCommand : IRequest<RemoveOneFeatureCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneFeatureCommand(int id)
        {
            Id = id;
        }
    }
}
