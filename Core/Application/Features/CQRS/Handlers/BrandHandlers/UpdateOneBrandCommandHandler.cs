using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForBrand;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateOneBrandCommandHandler
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

        public async Task<GetOneBrandByIdQueryResult> Handle(UpdateOneBrandCommand updateOneBrandCommand)
        {
            if (updateOneBrandCommand is null)
                throw new BrandObjectNullBadRequestException();
            var unchangedEntity = _repositoryManager.BrandRepository.GetByFilter(x => x.Id.Equals(updateOneBrandCommand.Id),true).SingleOrDefault();
            if (unchangedEntity is null)
                throw new BrandNotFoundException(updateOneBrandCommand.Id);
            unchangedEntity.Id = updateOneBrandCommand.Id;
            unchangedEntity.Name = updateOneBrandCommand.Name;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<GetOneBrandByIdQueryResult>(unchangedEntity);
        }
    }
}
