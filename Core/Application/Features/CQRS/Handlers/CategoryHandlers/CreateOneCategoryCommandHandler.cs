using Application.Features.CQRS.Commands.CategoryCommands;
using Application.Features.CQRS.Results.CategoryResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForCategory;

namespace Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateOneCategoryCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOneCategoryCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateOneCategoryCommandResult> Handle(CreateOneCategoryCommand createOneCategoryCommand)
        {
           
            var newCategory = _mapper.Map<Category>(createOneCategoryCommand);
            newCategory.CreatedDate = DateTime.UtcNow;
            newCategory.IsActive = true;
            newCategory.IsDeleted = false;
            await _repositoryManager.CategoryRepository.CreateAsync(newCategory);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<CreateOneCategoryCommandResult>(newCategory);


        }
    }
}
