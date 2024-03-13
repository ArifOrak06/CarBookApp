using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions.ExceptionsForCategory;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateOneCategoryCommandHandler
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

        public async Task<UpdateOneCategoryCommandResult> Handle(UpdateOneCategoryCommand updateOneCategoryCommand)
        {
         
            var currentEntity = _repositoryManager.CategoryRepository.GetByFilter(x => x.Id.Equals(updateOneCategoryCommand.Id), true).SingleOrDefault();
            if (currentEntity == null)
                throw new CategoryNotFoundException(updateOneCategoryCommand.Id);
            currentEntity.ModifiedDate = DateTime.UtcNow;
            currentEntity.IsActive = updateOneCategoryCommand.IsActive;
            if (updateOneCategoryCommand.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;

            currentEntity.Description = updateOneCategoryCommand.Description;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneCategoryCommandResult>(currentEntity);
            
        }

    }
}
