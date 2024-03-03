using Application.Features.CQRS.Commands.BannerCommands;
using Application.Features.CQRS.Commands.ContactCommands;
using Application.Repositories;
using Application.UnitOfWorks;
using Domain.Exceptions.ExceptionsForContact;

namespace Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveOneContactCommandHandler
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveOneContactCommandHandler(IRepositoryManager repositoryManager, IUnitOfWork unitOfWork)
        {
            _repositoryManager = repositoryManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(RemoveOneContactCommand removeOneContactCommand)
        {
            var deletedEntity = _repositoryManager.ContactRepository.GetByFilter(x => x.Id.Equals(removeOneContactCommand.Id), true).SingleOrDefault();
            if (deletedEntity is null)
                throw new ContactNotFoundException(removeOneContactCommand.Id);
            _repositoryManager.ContactRepository.Delete(deletedEntity);
            await _unitOfWork.CommitAsync();
            return removeOneContactCommand.Id;
        }
    }
}
