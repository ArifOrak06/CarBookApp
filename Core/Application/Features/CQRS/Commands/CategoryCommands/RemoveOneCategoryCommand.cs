using Application.Features.CQRS.Results.CategoryResults;
using MediatR;

namespace Application.Features.CQRS.Commands.CategoryCommands
{
    public class RemoveOneCategoryCommand : IRequest<RemoveOneCategoryCommandResult>
    {
        public int Id { get; set; }
        public RemoveOneCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
