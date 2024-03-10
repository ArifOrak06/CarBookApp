using Application.Features.CQRS.Results.ProvidedServiceResults;
using MediatR;

namespace Application.Features.CQRS.Commands.ProvidedServiceCommands
{
    public class UpdateOneProvidedServiceCommand : IRequest<UpdateOneProvidedServiceCommandResult>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
