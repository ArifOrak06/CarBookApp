using Application.Features.CQRS.Results.AboutResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForAboutCommands;
using MediatR;

namespace Application.Features.CQRS.Commands
{
    public class CreateOneAboutCommand : AboutCommandForManipulation, IRequest<CreateOneAboutCommandResult>
    {
        
    }
}
