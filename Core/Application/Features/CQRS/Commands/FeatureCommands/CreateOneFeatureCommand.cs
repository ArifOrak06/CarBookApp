using Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
    public class CreateOneFeatureCommand : IRequest<CreateOneFeatureCommandResult>
    {
        public string Name { get; set; }
    }
}
