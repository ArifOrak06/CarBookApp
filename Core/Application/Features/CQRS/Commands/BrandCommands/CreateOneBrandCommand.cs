using Application.Features.CQRS.Results.BrandResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForBrandCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class CreateOneBrandCommand : BrandCommandForManipulation,IRequest<CreateOneBrandCommandResult>
    {
        
    }
}
