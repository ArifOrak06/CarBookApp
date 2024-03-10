using Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace Application.Features.CQRS.Commands.PricingCommands
{
    public class UpdateOnePricingCommand : IRequest<UpdateOnePricingCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
