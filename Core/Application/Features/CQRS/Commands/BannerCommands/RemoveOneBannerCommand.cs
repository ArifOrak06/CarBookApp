using Application.Features.CQRS.Results.BannerResults;
using MediatR;

namespace Application.Features.CQRS.Commands.BannerCommands
{
    public class RemoveOneBannerCommand  : IRequest<RemoveOneBannerCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneBannerCommand(int id)
        {
            Id = id;
        }
    }
}
