using Application.Features.CQRS.Commands.BannerCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Entities;
using Domain.Exceptions.ExceptionsForBanner;

namespace Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveOneBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneBannerCommandHandler(IRepository<Banner> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task Handle(RemoveOneBannerCommand removeOneBannerCommand)
        {
            var currentEntity = _repository.GetByFilter(x => x.Id == removeOneBannerCommand.Id, true).SingleOrDefault();
            if (currentEntity != null)
                throw new BannerNotFoundException(removeOneBannerCommand.Id);
            _repository.Delete(currentEntity);
            await _unitOfWork.CommitAsync();


        }
    }
}
