using Application.Features.CQRS.Commands.BrandCommands;
using Application.Features.CQRS.Results.BrandResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForBrand;
using MediatR;

namespace Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveOneBrandCommandHandler : IRequestHandler<RemoveOneBrandCommand,RemoveOneBrandCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveOneBrandCommandHandler(IRepositoryManager repositoryManager,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RemoveOneBrandCommandResult> Handle(RemoveOneBrandCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.BrandRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (currentEntity is null)
                throw new BrandNotFoundException(request.Id);

            _repositoryManager.BrandRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneBrandCommandResult(request.Id);
        }
    }
}
