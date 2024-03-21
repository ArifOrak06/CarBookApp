using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class CreateOneBrandCommandHandler : IRequestHandler<CreateOneBrandCommand,CreateOneBrandCommandResult>
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

        public async Task<CreateOneBrandCommandResult> Handle(CreateOneBrandCommand request, CancellationToken cancellationToken)
        {

            var newEntity = _mapper.Map<Brand>(request);
            newEntity.IsActive = true;
            newEntity.IsDeleted = false;
            newEntity.CreatedDate = DateTime.UtcNow;


            await _repositoryManager.BrandRepository.CreateAsync(newEntity);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneBrandCommandResult>(newEntity);
        }
    }
}
