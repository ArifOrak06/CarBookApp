using Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace Application.Features.CQRS.Commands.PricingCommands
{
    public class CreateOnePricingCommand : IRequest<CreateOnePricingCommandResult>
    {
        public string Name { get; set; }
    }
}
