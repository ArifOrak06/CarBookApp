using Application.Features.CQRS.Results.PricingResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForPricingCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.PricingCommands
{
    public class UpdateOnePricingCommand : PricingCommandForManipulation,IRequest<UpdateOnePricingCommandResult>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
