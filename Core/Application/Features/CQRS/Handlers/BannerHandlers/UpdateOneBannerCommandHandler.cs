using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Results.BannerResults;
using Application.Repositories;
using Application.UnitOfWorks;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBanner;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateOneBannerCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateOneBannerCommandHandler(IRepositoryManager repositoryManager, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOneBannerCommandResult> Handle(UpdateOneBannerCommand updateOneBannerCommand)
        {
            if (updateOneBannerCommand == null)
                throw new BannerObjectNullBadRequestException();
            var currentEntity = _repositoryManager.BannerRepository.GetByFilter(x => x.Id == updateOneBannerCommand.Id, true).SingleOrDefault();
            if (currentEntity == null)
                throw new BannerNotFoundException(updateOneBannerCommand.Id);
            currentEntity.Description = updateOneBannerCommand.Description;
            currentEntity.VideoDescription = updateOneBannerCommand.VideoDescription;
            currentEntity.VideoUrl = updateOneBannerCommand.VideoUrl;
            currentEntity.Title = updateOneBannerCommand.Title;
           
            currentEntity.IsActive = updateOneBannerCommand.IsActive;
            if (updateOneBannerCommand.IsActive) currentEntity.IsDeleted = false; else currentEntity.IsDeleted = true;
            currentEntity.ModifiedDate = DateTime.UtcNow;
            await _unitOfWork.CommitAsync();
            return _mapper.Map<UpdateOneBannerCommandResult>(currentEntity);

        }
    }
}
