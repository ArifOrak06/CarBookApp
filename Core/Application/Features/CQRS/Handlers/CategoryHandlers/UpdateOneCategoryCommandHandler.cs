using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCategory;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateOneCategoryCommandHandler : IRequestHandler<UpdateOneCategoryCommand,UpdateOneCategoryCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateOneCategoryCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneCategoryCommandResult> Handle(UpdateOneCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.CategoryRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (currentEntity == null)
                throw new CategoryNotFoundException(request.Id);
            currentEntity.ModifiedDate = DateTime.UtcNow;
            currentEntity.IsActive = request.IsActive;
            if (request.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;

            currentEntity.Description = request.Description;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneCategoryCommandResult>(currentEntity);
        }
    }
}
