using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForAboutCommands;

namespace Application.Features.CQRS.Commands.AboutCommands
{
    public class UpdateOneAboutCommand : AboutCommandForManipulation
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
