using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForCarCommands;

namespace Application.Features.CQRS.Commands.CarCommands
{
    public class UpdateOneCarCommand : CarCommandForManipulation
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
