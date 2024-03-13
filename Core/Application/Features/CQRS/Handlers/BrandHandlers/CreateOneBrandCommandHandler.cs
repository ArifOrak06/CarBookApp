using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBrand;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateOneBrandCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOneBrandCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IRepositoryManager repositoryManager)
        {

            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetOneBrandByIdQueryResult> Handle(CreateOneBrandCommand createOneBrandCommand)
        {
          

            var newEntity = _mapper.Map<Brand>(createOneBrandCommand);
            newEntity.IsActive = true;
            newEntity.IsDeleted = false;
            newEntity.CreatedDate = DateTime.UtcNow;

            
            await _repositoryManager.BrandRepository.CreateAsync(newEntity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<GetOneBrandByIdQueryResult>(newEntity);
        }
    }
}
