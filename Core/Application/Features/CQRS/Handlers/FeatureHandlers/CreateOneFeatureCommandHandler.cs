using Application.Features.CQRS.Commands.FeatureCommands;
using Application.Features.CQRS.Results.FeatureResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForFeature;
using MediatR;

namespace Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class CreateOneFeatureCommandHandler : IRequestHandler<CreateOneFeatureCommand, CreateOneFeatureCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneFeatureCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOneFeatureCommandResult> Handle(CreateOneFeatureCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
                throw new FeatureObjectNullBadRequestException();
            var newEntity = _mapper.Map<Feature>(request);
            newEntity.CreatedDate = DateTime.UtcNow;
            newEntity.IsDeleted = false;
            newEntity.IsActive = true;
            await _repositoryManager.FeatureRepository.CreateAsync(newEntity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneFeatureCommandResult>(newEntity);
        }
    }
}
