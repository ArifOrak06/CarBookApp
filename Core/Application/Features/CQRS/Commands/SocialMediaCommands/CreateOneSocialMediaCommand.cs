using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.CQRS.Commands.SocialMediaCommands
{
    public class CreateOneSocialMediaCommand : IRequest<CreateOneSocialMediaCommandResult>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}
