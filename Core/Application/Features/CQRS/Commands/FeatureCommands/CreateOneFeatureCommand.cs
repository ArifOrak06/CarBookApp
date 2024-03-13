using Application.Features.CQRS.Results.FeatureResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForFeatureCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.FeatureCommands
{
    public class CreateOneFeatureCommand : FeatureCommandForManipulation,IRequest<CreateOneFeatureCommandResult>
    {
   
    }
}
