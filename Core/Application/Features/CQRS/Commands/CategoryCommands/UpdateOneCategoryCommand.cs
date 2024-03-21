using Application.Features.CQRS.Results.CategoryResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForCategoryCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateOneCategoryCommand : CategoryCommandForManipulation, IRequest<UpdateOneCategoryCommandResult>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
