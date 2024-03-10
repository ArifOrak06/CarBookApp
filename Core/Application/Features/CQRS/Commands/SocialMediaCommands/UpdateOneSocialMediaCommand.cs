using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.CQRS.Commands.SocialMediaCommands
{
    public class UpdateOneSocialMediaCommand : IRequest<UpdateOneSocialMediaCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
    }
}
