using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateOneAboutCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOneAboutCommandHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<CreateOneAboutCommandResult> Handle(CreateOneAboutCommand createOneAboutCommand)
        {
       
            var createdAbout = await _repositoryManager.AboutRepository.CreateAsync(new About
            {
                Title = createOneAboutCommand.Title,
                Description = createOneAboutCommand.Description,
                ImageUrl = createOneAboutCommand.ImageUrl,
                CreatedDate = DateTime.UtcNow,
                IsActive = true,
                IsDeleted = false
            });
            await _unitOfWork.CommitAsync();

            return new CreateOneAboutCommandResult
            {
                Id = createdAbout.Id,
                Title = createdAbout.Title,
                
            };
            

        }
    }
}
