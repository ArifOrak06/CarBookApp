using Application.Features.CQRS.Commands.AboutCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveOneAboutCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneAboutCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(RemoveOneAboutCommand removeOneAboutCommand)
        {
            var currentAbout = _repositoryManager.AboutRepository.GetByFilter(x => x.Id.Equals(removeOneAboutCommand.Id), true).SingleOrDefault();
            if (currentAbout is null)
                throw new AboutNotFoundException(removeOneAboutCommand.Id);

            _repositoryManager.AboutRepository.Delete(currentAbout);
            await _unitOfWork.CommitAsync();


        }
    }
}
