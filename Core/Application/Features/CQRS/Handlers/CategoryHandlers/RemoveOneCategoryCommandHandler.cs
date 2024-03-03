using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForCategory;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveOneCategoryCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneCategoryCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(RemoveOneCategoryCommand removeOneCategoryCommand)
        {
            var currentEntity = _repositoryManager.CategoryRepository.GetByFilter(x => x.Id.Equals(removeOneCategoryCommand.Id), true).SingleOrDefault();
            if (currentEntity == null)
                throw new CategoryNotFoundException(removeOneCategoryCommand.Id);
            _repositoryManager.CategoryRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return removeOneCategoryCommand.Id;

        }
    }
}
