using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities.RequestFeatures;
using Domain.Exceptions.ExceptionsForBrand;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateOneBrandCommandHandler : IRequestHandler<UpdateOneBrandCommand,UpdateOneBrandCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneBrandCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneBrandCommandResult> Handle(UpdateOneBrandCommand request, CancellationToken cancellationToken)
        {
            var unchangedEntity = _repositoryManager.BrandRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (unchangedEntity is null)
                throw new BrandNotFoundException(request.Id);
         
            unchangedEntity.Name = request.Name;
            unchangedEntity.ModifiedDate = DateTime.UtcNow;
            unchangedEntity.IsActive = request.IsActive;
            if (request.IsActive) unchangedEntity.IsDeleted = false; else unchangedEntity.IsDeleted = true;

            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneBrandCommandResult>(unchangedEntity);
        }
    }
}
