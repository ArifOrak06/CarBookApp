using Application.Features.CQRS.Commands.ContactCommands;
using Application.Features.CQRS.Results.ContactResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForContact;
using MediatR;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveOneContactCommandHandler : IRequestHandler<RemoveOneContactCommand,RemoveOneContactCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneContactCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

       
        public async Task<RemoveOneContactCommandResult> Handle(RemoveOneContactCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _repositoryManager.ContactRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (deletedEntity is null)
                throw new ContactNotFoundException(request.Id);
            _repositoryManager.ContactRepository.Delete(deletedEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneContactCommandResult(request.Id);
        }
    }
}
