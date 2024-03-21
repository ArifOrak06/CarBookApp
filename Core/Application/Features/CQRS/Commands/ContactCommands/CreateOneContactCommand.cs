using Application.Features.CQRS.Results.ContactResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForContactCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.ContactCommands
{
    public class CreateOneContactCommand  : ContactCommandForManipulation, IRequest<CreateOneContactCommandResult>
    {


    }
}
