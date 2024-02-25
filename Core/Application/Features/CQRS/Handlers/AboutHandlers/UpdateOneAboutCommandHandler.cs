using Application.Features.CQRS.Commands;
using Application.Features.CQRS.Results;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateOneAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOneAboutCommandHandler(IRepository<About> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOneAboutCommandResult> Handle(UpdateOneAboutCommand updateOneAboutCommand)
        {
            if (updateOneAboutCommand == null)
                throw new AboutObjextNullBadRequestException();
            var result = _repository.GetByFilter(x => x.Id.Equals(updateOneAboutCommand.Id),true).SingleOrDefault();
            if (result is null)
                throw new AboutNotFoundException(updateOneAboutCommand.Id);

            result.Title = updateOneAboutCommand.Title;
            result.Description = updateOneAboutCommand.Description;
            if(updateOneAboutCommand.ImageUrl != null)
                result.ImageUrl = updateOneAboutCommand.ImageUrl;
            await _unitOfWork.CommitAsync();
            return new UpdateOneAboutCommandResult
            {
                Id = result.Id,
                Title = result.Title,
            };

        }
    }
}
