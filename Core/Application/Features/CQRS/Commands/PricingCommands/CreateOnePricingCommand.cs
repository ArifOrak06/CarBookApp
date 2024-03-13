using Application.Features.CQRS.Results.PricingResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForPricingCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.PricingCommands
{
    public class CreateOnePricingCommand :PricingCommandForManipulation, IRequest<CreateOnePricingCommandResult>
    {
    }
}
