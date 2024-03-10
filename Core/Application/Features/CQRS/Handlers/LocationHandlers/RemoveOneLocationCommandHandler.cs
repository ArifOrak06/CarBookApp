using Application.Features.CQRS.Commands.LocationCommands;
using Application.Features.CQRS.Results.LocationResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForLocation;
using MediatR;

namespace Application.Features.CQRS.Handlers.LocationHandlers
{
    public class RemoveOneLocationCommandHandler : IRequestHandler<RemoveOneLocationCommand, RemoveOneLocationCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneLocationCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveOneLocationCommandResult> Handle(RemoveOneLocationCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _repositoryManager.LocationRepository.GetByFilter(x => x.Id.Equals(request.Id),true).SingleOrDefault();
            if (deletedEntity == null)
                throw new LocationNotFoundException(request.Id);
            _repositoryManager.LocationRepository.Delete(deletedEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneLocationCommandResult(request.Id);
           
        }
    }
}
