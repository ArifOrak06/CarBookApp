using Application.Features.CQRS.Results.AboutResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForAboutCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class UpdateOneAboutCommand : AboutCommandForManipulation,IRequest<UpdateOneAboutCommandResult>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
