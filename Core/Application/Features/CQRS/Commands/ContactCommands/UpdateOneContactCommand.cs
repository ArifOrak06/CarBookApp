using Application.Features.CQRS.Results.ContactResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForContactCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateOneContactCommand : ContactCommandForManipulation, IRequest<UpdateOneContactCommandResult>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
