using Application.Features.CQRS.Results.FooterAddressResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForFooterAddressCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class CreateOneFooterAddressCommand : FooterAddressCommandForManipulation,IRequest<CreateOneFooterAddressCommandResult>
    {
  
    }
}
