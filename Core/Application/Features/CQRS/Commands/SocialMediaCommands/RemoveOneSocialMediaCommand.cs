using Application.Features.CQRS.Results.SocialMediaResults;
using MediatR;

namespace Application.Features.CQRS.Commands.SocialMediaCommands
{
    public class RemoveOneSocialMediaCommand : IRequest<RemoveOneSocialMediaCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneSocialMediaCommand(int id)
        {
            Id = id;
        }
    }
}
