using Application.Features.CQRS.Results.BannerResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForBannerCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class CreateOneBannerCommand : BannerCommandForManipulation,IRequest<CreateOneBannerCommandResult>
    {

    }
}
