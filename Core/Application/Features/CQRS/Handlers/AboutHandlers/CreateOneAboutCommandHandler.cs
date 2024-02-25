using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Results;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateOneAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOneAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<CreateOneAboutCommandResult> Handle(CreateOneAboutCommand createOneAboutCommand)
        {
            if(createOneAboutCommand is null)
                throw new AboutObjextNullBadRequestException();
            var createdAbout = await _repository.CreateAsync(new About
            {
                Title = createOneAboutCommand.Title,
                Description = createOneAboutCommand.Description,
                ImageUrl = createOneAboutCommand.ImageUrl,
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
