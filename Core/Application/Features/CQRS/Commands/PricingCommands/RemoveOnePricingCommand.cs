using Application.Features.CQRS.Results.PricingResults;
using MediatR;

namespace Application.Features.CQRS.Commands.PricingCommands
{
    public class RemoveOnePricingCommand : IRequest<RemoveOnePricingCommandResult>
    {
        public int Id { get; set; }

        public RemoveOnePricingCommand(int id)
        {
            Id = id;
        }
    }
}
