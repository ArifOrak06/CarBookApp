using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForFeature;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class UpdateOneFeatureCommandHandler : IRequestHandler<UpdateOneFeatureCommand, UpdateOneFeatureCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneFeatureCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneFeatureCommandResult> Handle(UpdateOneFeatureCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new FeatureObjectNullBadRequestException();
            var currentEntity = _repositoryManager.FeatureRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (currentEntity is null)
                throw new FeatureNotFoundException(request.Id);
            currentEntity.IsActive = request.IsActive;
            if (currentEntity.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = false;
            currentEntity.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneFeatureCommandResult>(request);   
          
        }
    }
}
