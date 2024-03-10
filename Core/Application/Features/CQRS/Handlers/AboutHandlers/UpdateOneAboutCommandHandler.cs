using Application.Features.CQRS.Commands.AboutCommands;
using Application.Features.CQRS.Results.AboutResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateOneAboutCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOneAboutCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateOneAboutCommandResult> Handle(UpdateOneAboutCommand updateOneAboutCommand)
        {
            if (updateOneAboutCommand == null)
                throw new AboutObjextNullBadRequestException();
            var result = _repositoryManager.AboutRepository.GetByFilter(x => x.Id.Equals(updateOneAboutCommand.Id),true).SingleOrDefault();
            if (result is null)
                throw new AboutNotFoundException(updateOneAboutCommand.Id);

            result.Title = updateOneAboutCommand.Title;
            result.Description = updateOneAboutCommand.Description;
            result.IsActive = updateOneAboutCommand.IsActive;
            result.ModifiedDate = DateTime.UtcNow;
            if (updateOneAboutCommand.IsActive) result.IsDeleted = false; else result.IsDeleted = true;
            if(updateOneAboutCommand.ImageUrl != null)
                result.ImageUrl = updateOneAboutCommand.ImageUrl;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneAboutCommandResult>(result);

        }
    }
}
