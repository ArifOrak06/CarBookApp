using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForCategoryCommands;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateOneCategoryCommand : CategoryCommandForManipulation
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
