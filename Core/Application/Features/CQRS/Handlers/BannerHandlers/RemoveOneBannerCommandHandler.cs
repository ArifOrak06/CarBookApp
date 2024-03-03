using Application.Features.CQRS.Commands.BannerCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBanner;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveOneBannerCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneBannerCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(RemoveOneBannerCommand removeOneBannerCommand)
        {
            var currentEntity = _repositoryManager.BannerRepository.GetByFilter(x => x.Id == removeOneBannerCommand.Id, true).SingleOrDefault();
            if (currentEntity != null)
                throw new BannerNotFoundException(removeOneBannerCommand.Id);
            _repositoryManager.BannerRepository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();


        }
    }
}
