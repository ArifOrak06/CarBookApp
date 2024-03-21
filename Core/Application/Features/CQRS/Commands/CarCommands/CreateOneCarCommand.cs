using Application.Features.CQRS.Results.CarResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForCarCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CarCommands
{
    public class CreateOneCarCommand : CarCommandForManipulation,IRequest<CreateOneCarCommandResult>
    {

   
    }


   
}
