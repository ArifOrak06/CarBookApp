using Application.Features.CQRS.Results.ProvidedServiceResults;
using MediatR;

namespace Application.Features.CQRS.Commands.ProvidedServiceCommands
{
    public class RemoveOneProvidedServiceCommand : IRequest<RemoveOneProvidedServiceCommandResult>
    {
        public int Id { get; set; }

        public RemoveOneProvidedServiceCommand(int id)
        {
            Id = id;
        }
    }
}
