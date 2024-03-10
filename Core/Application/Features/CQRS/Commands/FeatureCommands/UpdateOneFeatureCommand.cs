using Application.Features.CQRS.Results.FeatureResults;
using MediatR;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
    public class UpdateOneFeatureCommand : IRequest<UpdateOneFeatureCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
