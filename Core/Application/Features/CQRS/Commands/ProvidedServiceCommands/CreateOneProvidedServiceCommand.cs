using Application.Features.CQRS.Results.ProvidedServiceResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForProvidedServiceCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.ProvidedServiceCommands
{
    public class CreateOneProvidedServiceCommand :ProvidedServiceCommandForManipulation, IRequest<CreateOneProvidedServiceCommandResult>
    {

    }
}
