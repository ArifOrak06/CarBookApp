using Application.Features.CQRS.Results.BrandResults;
using MediatR;

namespace Application.Features.CQRS.Commands.BrandCommands
{
    public class RemoveOneBrandCommand : IRequest<RemoveOneBrandCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneBrandCommand(int id)
        {
            Id= id; 
        }
    }
}
