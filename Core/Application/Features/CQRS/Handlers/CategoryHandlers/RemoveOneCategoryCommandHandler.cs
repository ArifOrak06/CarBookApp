using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForCategory;
using MediatR;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveOneCategoryCommandHandler : IRequestHandler<RemoveOneCategoryCommand,RemoveOneCategoryCommandResult>
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneCategoryCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

      
        public async Task<RemoveOneCategoryCommandResult> Handle(RemoveOneCategoryCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = _repositoryManager.CategoryRepository.GetByFilter(x => x.Id.Equals(request.Id), true).SingleOrDefault();
            if (currentEntity == null)
                throw new CategoryNotFoundException(request.Id);
            _repositoryManager.CategoryRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();
            return new RemoveOneCategoryCommandResult(request.Id);
        }
    }
}
