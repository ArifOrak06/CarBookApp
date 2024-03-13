using Application.Features.CQRS.Results.FooterAddressResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForFooterAddressCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.FooterAddressCommands
{
    public class UpdateOneFooterAddressCommand : FooterAddressCommandForManipulation, IRequest<UpdateOneFooterAddressCommandResult>
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
    }
}
