using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForFeature;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class RemoveOneFeatureCommandHandler : IRequestHandler<RemoveOneFeatureCommand, RemoveOneFeatureCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        

        public RemoveOneFeatureCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<RemoveOneFeatureCommandResult> Handle(RemoveOneFeatureCommand request, CancellationToken cancellationToken)
        {
            var deletedEntity = _repositoryManager.FeatureRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (deletedEntity == null)
                throw new FeatureNotFoundException(request.Id);
            _repositoryManager.FeatureRepository.Delete(deletedEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneFeatureCommandResult(request.Id);
         
        }
    }
}
