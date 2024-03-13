using Application.Features.CQRS.Results.LocationResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForLocationCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.LocationCommands
{
    public class UpdateOneLocationCommand : LocationCommandForManipulation, IRequest<UpdateOneLocationCommandResult>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
