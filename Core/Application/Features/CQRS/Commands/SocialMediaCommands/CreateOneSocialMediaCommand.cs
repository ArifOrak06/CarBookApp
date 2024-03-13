using Application.Features.CQRS.Results.SocialMediaResults;
using Application.ValidationRulesForQueriesAndCommands.ValidationRulesForCommands.ValidationRulesForSocialMediaCommands;
using MediatR;

namespace Application.Features.CQRS.Commands.SocialMediaCommands
{
    public class CreateOneSocialMediaCommand : SocialMediaCommandForManipulation,IRequest<CreateOneSocialMediaCommandResult>
    {
    }
}
