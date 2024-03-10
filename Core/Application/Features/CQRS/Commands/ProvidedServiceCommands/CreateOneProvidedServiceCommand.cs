using Application.Features.CQRS.Results.ProvidedServiceResults;
using MediatR;

namespace Application.Features.CQRS.Commands.ProvidedServiceCommands
{
    public class CreateOneProvidedServiceCommand : IRequest<CreateOneProvidedServiceCommandResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
