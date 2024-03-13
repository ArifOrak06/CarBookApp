using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForContactCommands;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateOneContactCommand : ContactCommandForManipulation
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
